using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Queries
{
    public class GetSelectedSaylorBranchRequestHandler : IRequestHandler<GetSelectedSaylorBranchRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SaylorBranch> _SaylorBranchRepository;


        public GetSelectedSaylorBranchRequestHandler(ISchoolManagementRepository<SaylorBranch> SaylorBranchRepository)
        {
            _SaylorBranchRepository = SaylorBranchRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSaylorBranchRequest request, CancellationToken cancellationToken)
        {
            ICollection<SaylorBranch> codeValues = await _SaylorBranchRepository.FilterAsync(x => x.IsActive && x.SaylorBranchId != 20);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SaylorBranchId
            }).ToList();
            return selectModels;
        }
    }
}
