//using MediatR;
//using SchoolManagement.Application.Contracts.Persistence;
//using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;
//using SchoolManagement.Domain;
//using SchoolManagement.Shared.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries
//{
//    public class GetSelecedBudgetTransactionRequestHandler : IRequestHandler<GetSelectedBudgetTransactionRequest, List<SelectedModel>>
//    {
//        private readonly ISchoolManagementRepository<BudgetTransaction> _BudgetTransactionRepository;

//        private GetSelecedBudgetTransactionRequestHandler(ISchoolManagementRepository<BudgetTransaction> BudgetTransactionRepository)
//        {
//            _BudgetTransactionRepository = BudgetTransactionRepository;
//        }

//        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetTransactionRequest request, CancellationToken cancellationToken)
//        {
//            ICollection<BudgetTransaction> budgetTransactions = await _BudgetTransactionRepository.FilterAsync(x => x.BudgetTransactionId != 17);
//            List<SelectedModel> selectModels = budgetTransactions.Select(x => new SelectedModel
//            {
//                Text = x.BudgetTransactionId,
//                Value = x.BudgetTransactionId
//            }).ToList();
//            return selectModels;
//        }
//    }
//}
