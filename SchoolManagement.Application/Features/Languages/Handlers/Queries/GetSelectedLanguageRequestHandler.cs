using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Languages.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Languages.Handlers.Queries
{ 
    public class GetSelectedLanguageRequestHandler : IRequestHandler<GetSelectedLanguageRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Language> _LanguageRepository;


        public GetSelectedLanguageRequestHandler(ISchoolManagementRepository<Language> LanguageRepository)
        {
            _LanguageRepository = LanguageRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedLanguageRequest request, CancellationToken cancellationToken)
        {
            ICollection<Language> Languages = await _LanguageRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = Languages.Select(x => new SelectedModel 
            {
                Text = x.LanguageName,
                Value = x.LanguageId
            }).ToList();
            return selectModels;
        }
    }
}
