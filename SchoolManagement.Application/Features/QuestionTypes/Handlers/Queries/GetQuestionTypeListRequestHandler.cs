using SchoolManagement.Application.Features.QuestionTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.QuestionType;
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


namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Queries
{
    public class GetQuestionTypeListRequestHandler : IRequestHandler<GetQuestionTypeListRequest, PagedResult<QuestionTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.QuestionType> _QuestionTypeRepository;

        private readonly IMapper _mapper;

        public GetQuestionTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.QuestionType> QuestionTypeRepository, IMapper mapper)
        {
            _QuestionTypeRepository = QuestionTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<QuestionTypeDto>> Handle(GetQuestionTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.QuestionType> QuestionTypes = _QuestionTypeRepository.FilterWithInclude(x => (x.Question.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = QuestionTypes.Count();
            QuestionTypes = QuestionTypes.OrderByDescending(x => x.QuestionTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var QuestionTypeDtos = _mapper.Map<List<QuestionTypeDto>>(QuestionTypes);
            var result = new PagedResult<QuestionTypeDto>(QuestionTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
