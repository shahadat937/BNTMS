using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Queries
{
    public class GetAvailableBalanceByBudgetCodeIdRequestHandler : IRequestHandler<GetAvailableBalanceByBudgetCodeIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BudgetCode> _BudgetCodeRepository;


        public GetAvailableBalanceByBudgetCodeIdRequestHandler(ISchoolManagementRepository<BudgetCode> BudgetCodeRepository)
        {
            _BudgetCodeRepository = BudgetCodeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetAvailableBalanceByBudgetCodeIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<BudgetCode> codeValues = await _BudgetCodeRepository.FilterAsync(x => x.IsActive && x.BudgetCodeId == request.BudgetCodeId);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AvailableAmount,
                Value = x.BudgetCodeId 
            }).ToList();
            return selectModels;
        }
    }
}
