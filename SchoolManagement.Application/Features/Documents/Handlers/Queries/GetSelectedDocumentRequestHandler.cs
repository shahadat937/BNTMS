using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Documents.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Documents.Handlers.Queries
{
    public class GetSelectedDocumentRequestHandler : IRequestHandler<GetSelectedDocumentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Document> _DocumentRepository;


        public GetSelectedDocumentRequestHandler(ISchoolManagementRepository<Document> DocumentRepository)
        {
            _DocumentRepository = DocumentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDocumentRequest request, CancellationToken cancellationToken)
        {
            ICollection<Document> codeValues = await _DocumentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DocumentName,
                Value = x.DocumentId
            }).ToList();
            return selectModels;
        }
    }
}
