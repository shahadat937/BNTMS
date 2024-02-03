using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Queries
{
    public class GetSelectedBudgetTypeRequestHandler : IRequestHandler<GetSelectedBudgetTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BudgetType> _BudgetTypeRepository;


        public GetSelectedBudgetTypeRequestHandler(ISchoolManagementRepository<BudgetType> BudgetTypeRepository)
        {
            _BudgetTypeRepository = BudgetTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BudgetType> codeValues = await _BudgetTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BudgetTypeName,
                Value = x.BudgetTypeId
            }).ToList();
            return selectModels;
        }
    }
}
