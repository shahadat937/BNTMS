using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
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

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Queries
{
    public class GetTraineeAssessmentMarkListRequestHandler : IRequestHandler<GetTraineeAssessmentMarkListRequest, PagedResult<TraineeAssessmentMarkDto>>
    {

        private readonly ISchoolManagementRepository<TraineeAssessmentMark> _TraineeAssessmentMarkRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssessmentMarkListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssessmentMark> TraineeAssessmentMarkRepository, IMapper mapper)
        {
            _TraineeAssessmentMarkRepository = TraineeAssessmentMarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeAssessmentMarkDto>> Handle(GetTraineeAssessmentMarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<TraineeAssessmentMark> TraineeAssessmentMarks = _TraineeAssessmentMarkRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "CourseDuration", "Trainee", "TraineeAssessmentCreate");
            var totalCount = TraineeAssessmentMarks.Count();
            TraineeAssessmentMarks = TraineeAssessmentMarks.OrderByDescending(x => x.TraineeAssessmentMarkId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeAssessmentMarkDtos = _mapper.Map<List<TraineeAssessmentMarkDto>>(TraineeAssessmentMarks);
            var result = new PagedResult<TraineeAssessmentMarkDto>(TraineeAssessmentMarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
