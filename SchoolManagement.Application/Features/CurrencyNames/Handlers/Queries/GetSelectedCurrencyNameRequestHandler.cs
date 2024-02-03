using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Queries
{
    public class GetSelectedCurrencyNameRequestHandler : IRequestHandler<GetSelectedCurrencyNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CurrencyName> _CurrencyNameRepository;


        public GetSelectedCurrencyNameRequestHandler(ISchoolManagementRepository<CurrencyName> CurrencyNameRepository)
        {
            _CurrencyNameRepository = CurrencyNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCurrencyNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<CurrencyName> CurrencyNames = await _CurrencyNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = CurrencyNames.Select(x => new SelectedModel 
            {
                Text = x.Name,
                Value = x.CurrencyNameId
            }).ToList();
            return selectModels;
        }
    }
}
