using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries
{
    public class GetBudgetTransactionListRequestHandler : IRequestHandler<GetBudgetTransactionListRequest, PagedResult<BudgetTransactionDto>>
    {
        private readonly ISchoolManagementRepository<BudgetTransaction> _budgetTransactionRepository;
        private readonly IMapper _mapper;

        public GetBudgetTransactionListRequestHandler(ISchoolManagementRepository<BudgetTransaction> budgetTransactionRepository, IMapper mapper)
        {
            _budgetTransactionRepository = budgetTransactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BudgetTransactionDto>> Handle(GetBudgetTransactionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

           
            IQueryable<BudgetTransaction> budgetTransactions = _budgetTransactionRepository
                .FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "BudgetCode", "BudgetType", "FiscalYear")
                .Where(x => x.BudgetCodeId == request.BudgetCodeId && x.BudgetTypeId == request.BudgetTypeId);

            var totalCount = budgetTransactions.Count(); // Total count after filtering

            // Apply ordering and pagination after filtering
            budgetTransactions = budgetTransactions
                .OrderByDescending(x => x.BudgetTransactionId)
                .Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize)
                .Take(request.QueryParams.PageSize);

            var budgetTransactionDtos = _mapper.Map<List<BudgetTransactionDto>>(budgetTransactions.ToList());
            var result = new PagedResult<BudgetTransactionDto>(budgetTransactionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


            //return result;
        }
    }
}
