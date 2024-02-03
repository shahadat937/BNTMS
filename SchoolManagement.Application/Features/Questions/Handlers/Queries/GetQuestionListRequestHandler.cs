using AutoMapper;
using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.Features.Questions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionListRequestHandler : IRequestHandler<GetQuestionListRequest, PagedResult<QuestionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Question> _QuestionRepository;

        private readonly IMapper _mapper;

        public GetQuestionListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Question> QuestionRepository, IMapper mapper)
        {
            _QuestionRepository = QuestionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<QuestionDto>> Handle(GetQuestionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Question> Questions = _QuestionRepository.FilterWithInclude(x => (x.Answer.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Questions.Count();
            Questions = Questions.OrderByDescending(x => x.QuestionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var QuestionDtos = _mapper.Map<List<QuestionDto>>(Questions);
            var result = new PagedResult<QuestionDto>(QuestionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
