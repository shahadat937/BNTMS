using SchoolManagement.Application.Features.Countrys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Country;
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


namespace SchoolManagement.Application.Features.Countrys.Handlers.Queries
{
    public class GetCountryListRequestHandler : IRequestHandler<GetCountryListRequest, PagedResult<CountryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Country> _CountryRepository;

        private readonly IMapper _mapper;

        public GetCountryListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Country> CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CountryDto>> Handle(GetCountryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Country> UTOfficerCategories = _CountryRepository.FilterWithInclude(x => x.CountryId != 217 && (x.CountryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.CountryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CountryDtos = _mapper.Map<List<CountryDto>>(UTOfficerCategories);
            var result = new PagedResult<CountryDto>(CountryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
