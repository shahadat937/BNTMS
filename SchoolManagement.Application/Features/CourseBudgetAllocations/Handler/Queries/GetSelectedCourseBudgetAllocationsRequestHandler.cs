using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handlers.Queries
{ 
    public class GetSelectedCourseBudgetAllocationRequestHandler : IRequestHandler<GetSelectedCourseBudgetAllocationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseBudgetAllocation> _CourseBudgetAllocationRepository;


        public GetSelectedCourseBudgetAllocationRequestHandler(ISchoolManagementRepository<CourseBudgetAllocation> CourseBudgetAllocationRepository)
        {
            _CourseBudgetAllocationRepository = CourseBudgetAllocationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseBudgetAllocationRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseBudgetAllocation> CourseBudgetAllocations = await _CourseBudgetAllocationRepository.FilterAsync(x => x.CourseBudgetAllocationId !=17);
            List<SelectedModel> selectModels = CourseBudgetAllocations.Select(x => new SelectedModel 
            {
                Text = x.CourseBudgetAllocationId,
                Value = x.CourseBudgetAllocationId
            }).ToList();
            return selectModels;
        }
    }
}
 