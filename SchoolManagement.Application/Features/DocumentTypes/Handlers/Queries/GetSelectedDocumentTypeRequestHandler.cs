using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DocumentTypes.Handlers.Queries
{
    public class GetSelectedDocumentTypeRequestHandler : IRequestHandler<GetSelectedDocumentTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DocumentType> _DocumentTypeRepository;


        public GetSelectedDocumentTypeRequestHandler(ISchoolManagementRepository<DocumentType> DocumentTypeRepository)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDocumentTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<DocumentType> codeValues = await _DocumentTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DocumentTypeName,
                Value = x.DocumentTypeId
            }).ToList();
            return selectModels;
        }
    }
}
