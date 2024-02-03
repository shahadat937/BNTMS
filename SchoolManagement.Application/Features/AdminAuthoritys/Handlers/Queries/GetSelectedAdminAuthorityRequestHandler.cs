using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries;
using SchoolManagement.Shared.Models;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Queries
{
    public class GetSelectedAdminAuthorityRequestHandler : IRequestHandler<GetSelectedAdminAuthorityRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AdminAuthority> _AdminAuthorityRepository;

        public GetSelectedAdminAuthorityRequestHandler(ISchoolManagementRepository<AdminAuthority> AdminAuthorityRepository)
        {
            _AdminAuthorityRepository = AdminAuthorityRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedAdminAuthorityRequest request, CancellationToken cancellationToken)
        {
            ICollection<AdminAuthority> codeValues = await _AdminAuthorityRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AdminAuthorityName,
                Value = x.AdminAuthorityId
            }).ToList();
            return selectModels;
        }
    }
}
