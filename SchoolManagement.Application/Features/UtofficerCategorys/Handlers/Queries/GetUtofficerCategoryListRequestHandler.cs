using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries;
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

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Queries
{
    public class GetUtofficerCategoryListRequestHandler : IRequestHandler<GetUtofficerCategoryListRequest, PagedResult<UtofficerCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UtofficerCategory> _UtofficerCategoryRepository;

        private readonly IMapper _mapper;

        public GetUtofficerCategoryListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UtofficerCategory> UtofficerCategoryRepository, IMapper mapper)
        {
            _UtofficerCategoryRepository = UtofficerCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UtofficerCategoryDto>> Handle(GetUtofficerCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.UtofficerCategory> UtofficerCategorys = _UtofficerCategoryRepository.FilterWithInclude(x => (x.UtofficerCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UtofficerCategorys.Count();
            UtofficerCategorys = UtofficerCategorys.OrderByDescending(x => x.UtofficerCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var UtofficerCategoryDtos = _mapper.Map<List<UtofficerCategoryDto>>(UtofficerCategorys);
            var result = new PagedResult<UtofficerCategoryDto>(UtofficerCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
