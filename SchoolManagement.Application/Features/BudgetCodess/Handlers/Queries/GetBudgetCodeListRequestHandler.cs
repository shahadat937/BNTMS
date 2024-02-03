using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetCode;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Queries;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Queries
{
    public class GetBudgetCodeListRequestHandler : IRequestHandler<GetBudgetCodeListRequest, PagedResult<BudgetCodeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BudgetCode> _BudgetCodeRepository;

        private readonly IMapper _mapper;

        public GetBudgetCodeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BudgetCode> BudgetCodeRepository, IMapper mapper)
        {
            _BudgetCodeRepository = BudgetCodeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BudgetCodeDto>> Handle(GetBudgetCodeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BudgetCode> BudgetCodes = _BudgetCodeRepository.FilterWithInclude(x => (x.BudgetCodes.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BudgetCodes.Count();
            BudgetCodes = BudgetCodes.OrderByDescending(x => x.BudgetCodeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BudgetCodeDtos = _mapper.Map<List<BudgetCodeDto>>(BudgetCodes);
            var result = new PagedResult<BudgetCodeDto>(BudgetCodeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
