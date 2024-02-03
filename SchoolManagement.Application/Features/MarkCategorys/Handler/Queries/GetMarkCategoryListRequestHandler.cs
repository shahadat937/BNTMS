using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Queries;

namespace SchoolManagement.Application.Features.MarkCategorys.Handler.Queries
{
    public class GetMarkCategoryListRequestHandler : IRequestHandler<GetMarkCategoryListRequest, PagedResult<MarkCategoryDto>>
    { 

        private readonly ISchoolManagementRepository<MarkCategory> _MarkCategoryRepository;  

        private readonly IMapper _mapper;

        public GetMarkCategoryListRequestHandler(ISchoolManagementRepository<MarkCategory> MarkCategoryRepository, IMapper mapper)
        {
            _MarkCategoryRepository = MarkCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MarkCategoryDto>> Handle(GetMarkCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult.ToString());

            IQueryable<MarkCategory> MarkCategory = _MarkCategoryRepository.FilterWithInclude(x => (x.CategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MarkCategory.Count();
            MarkCategory = MarkCategory.OrderByDescending(x => x.MarkCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MarkCategoryDtos = _mapper.Map<List<MarkCategoryDto>>(MarkCategory);
            var result = new PagedResult<MarkCategoryDto>(MarkCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
