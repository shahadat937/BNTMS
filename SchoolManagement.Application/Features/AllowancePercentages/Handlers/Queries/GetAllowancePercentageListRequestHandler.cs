using SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Queries
{
    public class GetAllowancePercentageListRequestHandler : IRequestHandler<GetAllowancePercentageListRequest, PagedResult<AllowancePercentageDto>>
    {

        private readonly ISchoolManagementRepository<AllowancePercentage> _AllowancePercentageRepository;

        private readonly IMapper _mapper;

        public GetAllowancePercentageListRequestHandler(ISchoolManagementRepository<AllowancePercentage> AllowancePercentageRepository, IMapper mapper)
        {
            _AllowancePercentageRepository = AllowancePercentageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AllowancePercentageDto>> Handle(GetAllowancePercentageListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AllowancePercentage> AllowancePercentages = _AllowancePercentageRepository.FilterWithInclude(x => (x.AllowanceName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = AllowancePercentages.Count();
            AllowancePercentages = AllowancePercentages.OrderByDescending(x => x.AllowancePercentageId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AllowancePercentageDtos = _mapper.Map<List<AllowancePercentageDto>>(AllowancePercentages);
            var result = new PagedResult<AllowancePercentageDto>(AllowancePercentageDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
