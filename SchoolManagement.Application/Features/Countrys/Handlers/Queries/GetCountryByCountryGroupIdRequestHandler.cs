using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Countrys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Countrys.Handlers.Queries
{
    public class GetCountryByCountryGroupIdRequestHandler : IRequestHandler<GetCountryByCountryGroupIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Country> _CountryRepository;

          
        public GetCountryByCountryGroupIdRequestHandler(ISchoolManagementRepository<Country> CountryRepository)
        {
            _CountryRepository = CountryRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCountryByCountryGroupIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<Country> Countrys = await _CountryRepository.FilterAsync(x =>x.CountryGroupId == request.CountryGroupId);
            List<SelectedModel> selectModels = Countrys.Select(x => new SelectedModel
            {
                Text = x.CountryName, 
                Value = x.CountryId 
            }).ToList();
            return selectModels;
        }
    }
}
