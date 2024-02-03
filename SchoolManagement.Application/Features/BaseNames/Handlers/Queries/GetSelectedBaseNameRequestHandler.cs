using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BaseNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BaseNames.Handlers.Queries
{
    public class GetSelectedBaseNameRequestHandler : IRequestHandler<GetSelectedBaseNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BaseName> _BaseNameRepository;


        public GetSelectedBaseNameRequestHandler(ISchoolManagementRepository<BaseName> BaseNameRepository)
        {
            _BaseNameRepository = BaseNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBaseNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<BaseName> codeValues = await _BaseNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BaseNames,
                Value = x.BaseNameId
            }).ToList();
            return selectModels;
        }
    }
}
