using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CountryGroups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Queries
{
    public class GetSelectedCountryGroupRequestHandler : IRequestHandler<GetSelectedCountryGroupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CountryGroup> _CountryGroupRepository;


        public GetSelectedCountryGroupRequestHandler(ISchoolManagementRepository<CountryGroup> CountryGroupRepository)
        {
            _CountryGroupRepository = CountryGroupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCountryGroupRequest request, CancellationToken cancellationToken)
        {
            ICollection<CountryGroup> CountryGroups = await _CountryGroupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = CountryGroups.Select(x => new SelectedModel 
            {
                Text = x.Name,
                Value = x.CountryGroupId
            }).ToList();
            return selectModels;
        }
    }
}
