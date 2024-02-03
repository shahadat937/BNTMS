using SchoolManagement.Application.Features.CountryGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CountryGroup;
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

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Queries
{
    public class GetCountryGroupListRequestHandler : IRequestHandler<GetCountryGroupListRequest, PagedResult<CountryGroupDto>>
    {

        private readonly ISchoolManagementRepository<CountryGroup> _CountryGroupRepository;

        private readonly IMapper _mapper;

        public GetCountryGroupListRequestHandler(ISchoolManagementRepository<CountryGroup> CountryGroupRepository, IMapper mapper)
        {
            _CountryGroupRepository = CountryGroupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CountryGroupDto>> Handle(GetCountryGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CountryGroup> CountryGroups = _CountryGroupRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CountryGroups.Count();
            CountryGroups = CountryGroups.OrderByDescending(x => x.CountryGroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CountryGroupDtos = _mapper.Map<List<CountryGroupDto>>(CountryGroups);
            var result = new PagedResult<CountryGroupDto>(CountryGroupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
