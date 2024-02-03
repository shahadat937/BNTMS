using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
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


namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Queries
{
    public class GetNewEntryEvaluationListRequestHandler : IRequestHandler<GetNewEntryEvaluationListRequest, PagedResult<NewEntryEvaluationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NewEntryEvaluation> _NewEntryEvaluationRepository;

        private readonly IMapper _mapper;

        public GetNewEntryEvaluationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NewEntryEvaluation> NewEntryEvaluationRepository, IMapper mapper)
        {
            _NewEntryEvaluationRepository = NewEntryEvaluationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NewEntryEvaluationDto>> Handle(GetNewEntryEvaluationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.NewEntryEvaluation> NewEntryEvaluations = _NewEntryEvaluationRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "Trainee.Rank", "CourseWeek");
            var totalCount = NewEntryEvaluations.Count();
            NewEntryEvaluations = NewEntryEvaluations.OrderByDescending(x => x.NewEntryEvaluationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NewEntryEvaluationDtos = _mapper.Map<List<NewEntryEvaluationDto>>(NewEntryEvaluations);
            var result = new PagedResult<NewEntryEvaluationDto>(NewEntryEvaluationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
