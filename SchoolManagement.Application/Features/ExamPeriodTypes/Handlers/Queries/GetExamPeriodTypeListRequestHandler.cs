using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Queries
{
    public class GetExamPeriodTypeListRequestHandler : IRequestHandler<GetExamPeriodTypeListRequest, PagedResult<ExamPeriodTypeDto>>
    {

        private readonly ISchoolManagementRepository<ExamPeriodType> _ExamPeriodTypeRepository;

        private readonly IMapper _mapper;

        public GetExamPeriodTypeListRequestHandler(ISchoolManagementRepository<ExamPeriodType> ExamPeriodTypeRepository, IMapper mapper)
        {
            _ExamPeriodTypeRepository = ExamPeriodTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamPeriodTypeDto>> Handle(GetExamPeriodTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ExamPeriodType> ExamPeriodTypes = _ExamPeriodTypeRepository.FilterWithInclude(x => (x.ExamPeriodName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ExamPeriodTypes.Count();
            ExamPeriodTypes = ExamPeriodTypes.OrderByDescending(x => x.ExamPeriodTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamPeriodTypeDtos = _mapper.Map<List<ExamPeriodTypeDto>>(ExamPeriodTypes);
            var result = new PagedResult<ExamPeriodTypeDto>(ExamPeriodTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
