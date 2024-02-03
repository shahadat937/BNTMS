using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Branchs.Handlers.Queries
{ 
    public class GetSelectedBranchForJCOsRequestHandler : IRequestHandler<GetSelectedBranchForJCOsRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Branch> _BranchRepository;


        public GetSelectedBranchForJCOsRequestHandler(ISchoolManagementRepository<Branch> BranchRepository)
        {
            _BranchRepository = BranchRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBranchForJCOsRequest request, CancellationToken cancellationToken)
        {
            ICollection<Branch> Branchs = await _BranchRepository.FilterAsync(x => x.BranchId ==17);
            List<SelectedModel> selectModels = Branchs.Select(x => new SelectedModel 
            {
                Text = x.BranchName,
                Value = x.BranchId
            }).ToList();
            return selectModels;
        }
    }
}
 