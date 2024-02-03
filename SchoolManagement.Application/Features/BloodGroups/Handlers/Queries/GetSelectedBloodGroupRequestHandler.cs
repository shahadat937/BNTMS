using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BloodGroups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BloodGroups.Handlers.Queries
{ 
    public class GetSelectedBloodGroupRequestHandler : IRequestHandler<GetSelectedBloodGroupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BloodGroup> _BloodGroupRepository;


        public GetSelectedBloodGroupRequestHandler(ISchoolManagementRepository<BloodGroup> BloodGroupRepository)
        {
            _BloodGroupRepository = BloodGroupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBloodGroupRequest request, CancellationToken cancellationToken)
        {
            ICollection<BloodGroup> BloodGroups = await _BloodGroupRepository.FilterAsync(x => x.IsActive && x.BloodGroupId !=26);
            List<SelectedModel> selectModels = BloodGroups.Select(x => new SelectedModel 
            {
                Text = x.BloodGroupName,
                Value = x.BloodGroupId
            }).ToList();
            return selectModels;
        }
    }
}
 