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
    public class GetAutoCompleteOrganizationNameRequestHandler : IRequestHandler<GetAutoCompleteOrganizationNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OrganizationName> _OrganizationNameRepository; 
        public GetAutoCompleteOrganizationNameRequestHandler(ISchoolManagementRepository<OrganizationName> OrganizationNameRepository)
        {
            _OrganizationNameRepository = OrganizationNameRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteOrganizationNameRequest request, CancellationToken cancellationToken)
        {
                ICollection<OrganizationName> traineeBioDataGeneralInfos = await _OrganizationNameRepository.FilterAsync(x => x.IsActive && x.Name.Contains(request.Name));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.Name,
                    Value = x.OrganizationNameId
                }).ToList();
                return selectModels;
            }
      }
}
