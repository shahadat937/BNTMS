using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handler.Queries
{
    public class GetBudgetAllocationListRequestHandler : IRequestHandler<GetBudgetAllocationListRequest, PagedResult<BudgetAllocationDto>>
    { 

        private readonly ISchoolManagementRepository<BudgetAllocation> _BudgetAllocationRepository; 

        private readonly IMapper _mapper;

        public GetBudgetAllocationListRequestHandler(ISchoolManagementRepository<BudgetAllocation> BudgetAllocationRepository, IMapper mapper)
        {
            _BudgetAllocationRepository = BudgetAllocationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BudgetAllocationDto>> Handle(GetBudgetAllocationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<BudgetAllocation> BudgetAllocationes = _BudgetAllocationRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "BudgetCode", "BudgetType", "FiscalYear");
            var totalCount = BudgetAllocationes.Count();
            BudgetAllocationes = BudgetAllocationes.OrderByDescending(x => x.BudgetAllocationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=> x.BudgetCodeId == request.BudgetCodeId && x.FiscalYearId == request.FiscalYearId);

            var BudgetAllocationesDtos = _mapper.Map<List<BudgetAllocationDto>>(BudgetAllocationes);
            var result = new PagedResult<BudgetAllocationDto>(BudgetAllocationesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
