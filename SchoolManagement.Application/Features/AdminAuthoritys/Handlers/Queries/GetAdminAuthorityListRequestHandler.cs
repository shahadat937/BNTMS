using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Queries
{
    public class GetAdminAuthorityListRequestHandler : IRequestHandler<GetAdminAuthorityListRequest, PagedResult<AdminAuthorityDto>>
    {

        private readonly ISchoolManagementRepository<AdminAuthority> _AdminAuthorityRepository;

        private readonly IMapper _mapper;

        public GetAdminAuthorityListRequestHandler(ISchoolManagementRepository<AdminAuthority> AdminAuthorityRepository, IMapper mapper)
        {
            _AdminAuthorityRepository = AdminAuthorityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AdminAuthorityDto>> Handle(GetAdminAuthorityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AdminAuthority> UTOfficerCategories = _AdminAuthorityRepository.FilterWithInclude(x => (x.AdminAuthorityName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.AdminAuthorityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AdminAuthorityDtos = _mapper.Map<List<AdminAuthorityDto>>(UTOfficerCategories);
            var result = new PagedResult<AdminAuthorityDto>(AdminAuthorityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
