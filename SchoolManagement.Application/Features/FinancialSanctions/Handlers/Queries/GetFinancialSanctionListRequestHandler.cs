using SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries;
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
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Queries
{
    public class GetFinancialSanctionListRequestHandler : IRequestHandler<GetFinancialSanctionListRequest, PagedResult<FinancialSanctionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FinancialSanction> _FinancialSanctionRepository;

        private readonly IMapper _mapper;

        public GetFinancialSanctionListRequestHandler(ISchoolManagementRepository<FinancialSanction> FinancialSanctionRepository, IMapper mapper)
        {
            _FinancialSanctionRepository = FinancialSanctionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FinancialSanctionDto>> Handle(GetFinancialSanctionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<FinancialSanction> FinancialSanctions = _FinancialSanctionRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = FinancialSanctions.Count();
            FinancialSanctions = FinancialSanctions.OrderByDescending(x => x.FinancialSanctionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FinancialSanctionDtos = _mapper.Map<List<FinancialSanctionDto>>(FinancialSanctions);
            var result = new PagedResult<FinancialSanctionDto>(FinancialSanctionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
