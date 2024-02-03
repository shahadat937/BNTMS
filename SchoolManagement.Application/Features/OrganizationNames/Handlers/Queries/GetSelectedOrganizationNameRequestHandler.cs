using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Queries
{
    public class GetSelectedOrganizationNameRequestHandler : IRequestHandler<GetSelectedOrganizationNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OrganizationName> _OrganizationNameRepository;


        public GetSelectedOrganizationNameRequestHandler(ISchoolManagementRepository<OrganizationName> OrganizationNameRepository)
        {
            _OrganizationNameRepository = OrganizationNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOrganizationNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<OrganizationName> codeValues = await _OrganizationNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.OrganizationNameId
            }).ToList();
            return selectModels;
        }
    }
}
