using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handlers.Queries
{ 
    public class GetSelectedBudgetAllocationRequestHandler : IRequestHandler<GetSelectedBudgetAllocationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BudgetAllocation> _BudgetAllocationRepository;


        public GetSelectedBudgetAllocationRequestHandler(ISchoolManagementRepository<BudgetAllocation> BudgetAllocationRepository)
        {
            _BudgetAllocationRepository = BudgetAllocationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetAllocationRequest request, CancellationToken cancellationToken)
        {
            ICollection<BudgetAllocation> BudgetAllocations = await _BudgetAllocationRepository.FilterAsync(x => x.BudgetAllocationId !=17);
            List<SelectedModel> selectModels = BudgetAllocations.Select(x => new SelectedModel 
            {
                Text = x.BudgetAllocationId,
                Value = x.BudgetAllocationId
            }).ToList();
            return selectModels;
        }
    }
}
 