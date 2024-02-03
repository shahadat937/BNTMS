using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Queries
{
    public class GetSelectedMembershipTypeRequestHandler : IRequestHandler<GetSelectedMembershipTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberShipType> _MembershipTypeRepository;


        public GetSelectedMembershipTypeRequestHandler(ISchoolManagementRepository<MemberShipType> MembershipTypeRepository)
        {
            _MembershipTypeRepository = MembershipTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMembershipTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<MemberShipType> codeValues = await _MembershipTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MembershipTypeName,
                Value = x.MembershipTypeId
            }).ToList();
            return selectModels;
        }
    }
}
