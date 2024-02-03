using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamAttemptType;
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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Queries
{
    public class GetExamAttemptTypeListRequestHandler : IRequestHandler<GetExamAttemptTypeListRequest, PagedResult<ExamAttemptTypeDto>>
    {

        private readonly ISchoolManagementRepository<ExamAttemptType> _ExamAttemptTypeRepository;

        private readonly IMapper _mapper;

        public GetExamAttemptTypeListRequestHandler(ISchoolManagementRepository<ExamAttemptType> ExamAttemptTypeRepository, IMapper mapper)
        {
            _ExamAttemptTypeRepository = ExamAttemptTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamAttemptTypeDto>> Handle(GetExamAttemptTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ExamAttemptType> ExamAttemptTypes = _ExamAttemptTypeRepository.FilterWithInclude(x => (x.ExamAttemptTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ExamAttemptTypes.Count();
            ExamAttemptTypes = ExamAttemptTypes.OrderByDescending(x => x.ExamAttemptTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamAttemptTypeDtos = _mapper.Map<List<ExamAttemptTypeDto>>(ExamAttemptTypes);
            var result = new PagedResult<ExamAttemptTypeDto>(ExamAttemptTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
