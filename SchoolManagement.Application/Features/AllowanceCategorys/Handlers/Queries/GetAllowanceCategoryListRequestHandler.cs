using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Queries
{
    public class GetAllowanceCategoryListRequestHandler : IRequestHandler<GetAllowanceCategoryListRequest, PagedResult<AllowanceCategoryDto>>
    {

        private readonly ISchoolManagementRepository<AllowanceCategory> _AllowanceCategoryRepository;

        private readonly IMapper _mapper;

        public GetAllowanceCategoryListRequestHandler(ISchoolManagementRepository<AllowanceCategory> AllowanceCategoryRepository, IMapper mapper)
        {
            _AllowanceCategoryRepository = AllowanceCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AllowanceCategoryDto>> Handle(GetAllowanceCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AllowanceCategory> AllowanceCategorys = _AllowanceCategoryRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "FromRank", "ToRank", "CountryGroup", "Country", "CurrencyName", "AllowancePercentage");
            var totalCount = AllowanceCategorys.Count();
            AllowanceCategorys = AllowanceCategorys.OrderByDescending(x => x.AllowanceCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AllowanceCategoryDtos = _mapper.Map<List<AllowanceCategoryDto>>(AllowanceCategorys);
            var result = new PagedResult<AllowanceCategoryDto>(AllowanceCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
