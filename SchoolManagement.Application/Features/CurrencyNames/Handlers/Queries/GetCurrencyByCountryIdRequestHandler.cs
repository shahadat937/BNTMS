using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Queries
{
    public class GetCurrencyByCountryIdRequestHandler : IRequestHandler<GetCurrencyByCountryIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CurrencyName> _CurrencyNameRepository;

          
        public GetCurrencyByCountryIdRequestHandler(ISchoolManagementRepository<CurrencyName> CurrencyNameRepository)
        {
            _CurrencyNameRepository = CurrencyNameRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCurrencyByCountryIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CurrencyName> CurrencyNames = await _CurrencyNameRepository.FilterAsync(x =>x.CountryId == request.CountryId);
            List<SelectedModel> selectModels = CurrencyNames.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.CurrencyNameId 
            }).ToList();
            return selectModels;
        }
    }
}
