using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Queries
{
    public class GetSubBranchBySaylorBranchIdRequestHandler : IRequestHandler<GetSubBranchBySaylorBranchIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SaylorSubBranch> _SaylorSubBranchRepository;

          
        public GetSubBranchBySaylorBranchIdRequestHandler(ISchoolManagementRepository<SaylorSubBranch> SaylorSubBranchRepository)
        {
            _SaylorSubBranchRepository = SaylorSubBranchRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSubBranchBySaylorBranchIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<SaylorSubBranch> SaylorSubBranchs = await _SaylorSubBranchRepository.FilterAsync(x =>x.SaylorBranchId == request.SaylorBranchId && x.SaylorSubBranchId != 23);
            List<SelectedModel> selectModels = SaylorSubBranchs.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.SaylorSubBranchId 
            }).ToList();
            return selectModels;
        }
    }
}
