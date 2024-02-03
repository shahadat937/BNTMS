using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
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

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Queries
{
    public class GetTraineeAssessmentCreateListRequestHandler : IRequestHandler<GetTraineeAssessmentCreateListRequest, PagedResult<TraineeAssessmentCreateDto>>
    {

        private readonly ISchoolManagementRepository<TraineeAssessmentCreate> _TraineeAssessmentCreateRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssessmentCreateListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentCreate> TraineeAssessmentCreateRepository, IMapper mapper)
        {
            _TraineeAssessmentCreateRepository = TraineeAssessmentCreateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeAssessmentCreateDto>> Handle(GetTraineeAssessmentCreateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<TraineeAssessmentCreate> TraineeAssessmentCreates = _TraineeAssessmentCreateRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "CourseDuration.CourseName").Where(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId);
            var totalCount = TraineeAssessmentCreates.Count();
            TraineeAssessmentCreates = TraineeAssessmentCreates.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeAssessmentCreateDtos = _mapper.Map<List<TraineeAssessmentCreateDto>>(TraineeAssessmentCreates);
            var result = new PagedResult<TraineeAssessmentCreateDto>(TraineeAssessmentCreateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
