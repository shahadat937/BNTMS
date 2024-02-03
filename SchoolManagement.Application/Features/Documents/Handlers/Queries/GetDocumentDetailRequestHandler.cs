using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Document;
using SchoolManagement.Application.Features.Documents.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Documents.Handlers.Queries
{
    public class GetDocumentDetailRequestHandler : IRequestHandler<GetDocumentDetailRequest, DocumentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Document> _DocumentRepository;
        public GetDocumentDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Document> DocumentRepository, IMapper mapper)
        {
            _DocumentRepository = DocumentRepository;
            _mapper = mapper;
        }
        public async Task<DocumentDto> Handle(GetDocumentDetailRequest request, CancellationToken cancellationToken)
        {
            var Document = await _DocumentRepository.Get(request.DocumentId);
            return _mapper.Map<DocumentDto>(Document);
        }
    }
}
