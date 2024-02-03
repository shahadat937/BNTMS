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
    public class GetTargetAmountByBudgetCodeIdRequestHandler : IRequestHandler<GetTargetAmountByBudgetCodeIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BudgetCode> _BudgetCodeRepository;

        public GetTargetAmountByBudgetCodeIdRequestHandler(ISchoolManagementRepository<BudgetCode> BudgetCodeRepository)
        {
            _BudgetCodeRepository = BudgetCodeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetTargetAmountByBudgetCodeIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<BudgetCode> codeValues = await _BudgetCodeRepository.FilterAsync(x => x.IsActive && x.BudgetCodeId == request.BudgetCodeId);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.TargetAmount,  
                Value = x.BudgetCodeId 
            }).ToList();
            return selectModels;
        }
    }
}
