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
    public class GetSelectedBudgetCodeRequestHandler : IRequestHandler<GetSelectedBudgetCodeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BudgetCode> _BudgetCodeRepository;


        public GetSelectedBudgetCodeRequestHandler(ISchoolManagementRepository<BudgetCode> BudgetCodeRepository)
        {
            _BudgetCodeRepository = BudgetCodeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetCodeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BudgetCode> codeValues = await _BudgetCodeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BudgetCodes+" _ "+x.Name,
                Value = x.BudgetCodeId
            }).ToList();
            return selectModels;
        }
    }
}
