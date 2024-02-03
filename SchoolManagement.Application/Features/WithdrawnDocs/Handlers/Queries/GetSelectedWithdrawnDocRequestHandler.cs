using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Queries
{ 
    public class GetSelectedWithdrawnDocRequestHandler : IRequestHandler<GetSelectedWithdrawnDocRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<WithdrawnDoc> _WithdrawnDocRepository;


        public GetSelectedWithdrawnDocRequestHandler(ISchoolManagementRepository<WithdrawnDoc> WithdrawnDocRepository)
        {
            _WithdrawnDocRepository = WithdrawnDocRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedWithdrawnDocRequest request, CancellationToken cancellationToken)
        {
            ICollection<WithdrawnDoc> WithdrawnDocs = await _WithdrawnDocRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = WithdrawnDocs.Select(x => new SelectedModel 
            {
                Text = x.WithdrawnDocName,
                Value = x.WithdrawnDocId
            }).ToList();
            return selectModels;
        }
    }
}
