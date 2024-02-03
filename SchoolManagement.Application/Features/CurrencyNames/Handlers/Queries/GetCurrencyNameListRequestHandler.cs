using SchoolManagement.Application.Features.CurrencyNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CurrencyName;
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

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Queries
{
    public class GetCurrencyNameListRequestHandler : IRequestHandler<GetCurrencyNameListRequest, PagedResult<CurrencyNameDto>>
    {

        private readonly ISchoolManagementRepository<CurrencyName> _CurrencyNameRepository;

        private readonly IMapper _mapper;

        public GetCurrencyNameListRequestHandler(ISchoolManagementRepository<CurrencyName> CurrencyNameRepository, IMapper mapper)
        {
            _CurrencyNameRepository = CurrencyNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CurrencyNameDto>> Handle(GetCurrencyNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CurrencyName> CurrencyNames = _CurrencyNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CurrencyNames.Count();
            CurrencyNames = CurrencyNames.OrderByDescending(x => x.CurrencyNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CurrencyNameDtos = _mapper.Map<List<CurrencyNameDto>>(CurrencyNames);
            var result = new PagedResult<CurrencyNameDto>(CurrencyNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
