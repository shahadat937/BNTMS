using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;
using SchoolManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries
{
    public class GetBudgetTransactionListRequestHandler : IRequestHandler<GetBudgetTransactionListRequest, List<BudgetTransactionDto>>
    {
        private readonly ISchoolManagementRepository<BudgetTransaction> _budgetTransactionRepository;
        private readonly IMapper _mapper;

        public GetBudgetTransactionListRequestHandler(ISchoolManagementRepository<BudgetTransaction> budgetTransactionRepository, IMapper mapper)
        {
            _budgetTransactionRepository = budgetTransactionRepository;
            _mapper = mapper;
        }

        public async Task<List<BudgetTransactionDto>> Handle(GetBudgetTransactionListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BudgetTransaction> budgetTransactions = _budgetTransactionRepository.Where(x => x.BudgetCodeId == request.BudgetCodeId && x.BudgetTypeId == request.BudgetTypeId);

            var result = _mapper.Map<List<BudgetTransactionDto>>(budgetTransactions);

            return result;
        }
    }
}
