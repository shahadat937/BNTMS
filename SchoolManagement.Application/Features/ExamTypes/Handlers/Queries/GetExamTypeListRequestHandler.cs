using SchoolManagement.Application.Features.ExamTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamType;
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


namespace SchoolManagement.Application.Features.ExamTypes.Handlers.Queries
{
    public class GetExamTypeListRequestHandler : IRequestHandler<GetExamTypeListRequest, PagedResult<ExamTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ExamType> _ExamTypeRepository;

        private readonly IMapper _mapper;

        public GetExamTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ExamType> ExamTypeRepository, IMapper mapper)
        {
            _ExamTypeRepository = ExamTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamTypeDto>> Handle(GetExamTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ExamType> ExamTypes = _ExamTypeRepository.FilterWithInclude(x => (x.ExamTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ExamTypes.Count();
            ExamTypes = ExamTypes.OrderByDescending(x => x.ExamTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamTypeDtos = _mapper.Map<List<ExamTypeDto>>(ExamTypes);
            var result = new PagedResult<ExamTypeDto>(ExamTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
