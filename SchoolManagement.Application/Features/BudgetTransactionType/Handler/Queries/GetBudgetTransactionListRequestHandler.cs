using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries
{
    public class GetBudgetTransactionListRequestHandler : IRequestHandler<GetBudgetTransactionDetailRequest>
    {
        private readonly ISchoolManagementRepository<BudgetTransaction> _BudgetTransactionRepository;
        private readonly IMapper mapper;

        public GetBudgetTransactionListRequestHandler(ISchoolManagementRepository<BudgetTransaction> budgetTransactionRepository, IMapper mapper)
        {
            _BudgetTransactionRepository = budgetTransactionRepository;
            this.mapper = mapper;
        }
        public async Task<PagedResult<BudgetTransactionDto>> Handle(GetBudgetTransactionDetailRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<BudgetTransaction> BudgetTransaction = _BudgetTransactionRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "BudgetCode", "BudgetType", "CourseName");
        }
    }
}
