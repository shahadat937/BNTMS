using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Queries
{
    public class GetTdecQuationGroupListRequestHandler : IRequestHandler<GetTdecQuationGroupListRequest, PagedResult<TdecQuationGroupDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecQuationGroup> _TdecQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetTdecQuationGroupListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecQuationGroup> TdecQuationGroupRepository, IMapper mapper)
        {
            _TdecQuationGroupRepository = TdecQuationGroupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TdecQuationGroupDto>> Handle(GetTdecQuationGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TdecQuationGroup> TdecQuationGroups = _TdecQuationGroupRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BaseSchoolName", "CourseName", "BnaSubjectName", "Trainee", "TdecQuestionName");
            var totalCount = TdecQuationGroups.Count();
            TdecQuationGroups = TdecQuationGroups.OrderByDescending(x => x.TdecQuationGroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TdecQuationGroupDtos = _mapper.Map<List<TdecQuationGroupDto>>(TdecQuationGroups);
            var result = new PagedResult<TdecQuationGroupDto>(TdecQuationGroupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
