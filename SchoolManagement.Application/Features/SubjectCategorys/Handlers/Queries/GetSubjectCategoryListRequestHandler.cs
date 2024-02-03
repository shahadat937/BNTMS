using SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries;
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

using System.Text;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.SubjectCategorys;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Queries
{
    public class GetSubjectCategoryListRequestHandler : IRequestHandler<GetSubjectCategoryListRequest, PagedResult<SubjectCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SubjectCategory> _SubjectCategoryRepository;

        private readonly IMapper _mapper;

        public GetSubjectCategoryListRequestHandler(ISchoolManagementRepository<SubjectCategory> SubjectCategoryRepository, IMapper mapper)
        {
            _SubjectCategoryRepository = SubjectCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SubjectCategoryDto>> Handle(GetSubjectCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SubjectCategory> SubjectCategorys = _SubjectCategoryRepository.FilterWithInclude(x => (x.SubjectCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SubjectCategorys.Count();
            SubjectCategorys = SubjectCategorys.OrderByDescending(x => x.SubjectCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SubjectCategoryDtos = _mapper.Map<List<SubjectCategoryDto>>(SubjectCategorys);
            var result = new PagedResult<SubjectCategoryDto>(SubjectCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
