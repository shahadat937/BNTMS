using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Queries
{
    public class GetTraineeAssissmentGroupListRequestHandler : IRequestHandler<GetTraineeAssissmentGroupListRequest, PagedResult<TraineeAssissmentGroupDto>>
    {

        private readonly ISchoolManagementRepository<TraineeAssissmentGroup> _TraineeAssissmentGroupRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssissmentGroupListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssissmentGroup> TraineeAssissmentGroupRepository, IMapper mapper)
        {
            _TraineeAssissmentGroupRepository = TraineeAssissmentGroupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeAssissmentGroupDto>> Handle(GetTraineeAssissmentGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<TraineeAssissmentGroup> TraineeAssissmentGroups = _TraineeAssissmentGroupRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseDuration.CourseName");
            var totalCount = TraineeAssissmentGroups.Count();
            TraineeAssissmentGroups = TraineeAssissmentGroups.OrderByDescending(x => x.TraineeAssissmentGroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeAssissmentGroupDtos = _mapper.Map<List<TraineeAssissmentGroupDto>>(TraineeAssissmentGroups);
            var result = new PagedResult<TraineeAssissmentGroupDto>(TraineeAssissmentGroupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
