using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Queries
{
    public class GetSelectedSaylorSubBranchRequestHandler : IRequestHandler<GetSelectedSaylorSubBranchRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SaylorSubBranch> _SaylorSubBranchRepository;


        public GetSelectedSaylorSubBranchRequestHandler(ISchoolManagementRepository<SaylorSubBranch> SaylorSubBranchRepository)
        {
            _SaylorSubBranchRepository = SaylorSubBranchRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSaylorSubBranchRequest request, CancellationToken cancellationToken)
        {
            ICollection<SaylorSubBranch> codeValues = await _SaylorSubBranchRepository.FilterAsync(x => x.IsActive && x.SaylorSubBranchId != 23);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SaylorSubBranchId
            }).ToList();
            return selectModels;
        }
    }
}
