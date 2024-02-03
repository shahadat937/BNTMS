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
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Application.DTOs.SubjectTypes;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Queries
{
    public class GetSubjectTypeListRequestHandler : IRequestHandler<GetSubjectTypeListRequest, PagedResult<SubjectTypeDto>>
    {

        private readonly ISchoolManagementRepository<SubjectType> _SubjectTypeRepository;

        private readonly IMapper _mapper;

        public GetSubjectTypeListRequestHandler(ISchoolManagementRepository<SubjectType> SubjectTypeRepository, IMapper mapper)
        {
            _SubjectTypeRepository = SubjectTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SubjectTypeDto>> Handle(GetSubjectTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SubjectType> SubjectTypes = _SubjectTypeRepository.FilterWithInclude(x => (x.SubjectTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SubjectTypes.Count();
            SubjectTypes = SubjectTypes.OrderByDescending(x => x.SubjectTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SubjectTypeDtos = _mapper.Map<List<SubjectTypeDto>>(SubjectTypes);
            var result = new PagedResult<SubjectTypeDto>(SubjectTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
