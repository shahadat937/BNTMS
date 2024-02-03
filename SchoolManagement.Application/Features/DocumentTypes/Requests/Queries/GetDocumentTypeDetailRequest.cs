using MediatR;
using SchoolManagement.Application.DTOs.DocumentTypes;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Queries
{
    public class GetDocumentTypeDetailRequest : IRequest<DocumentTypeDto>
    {
        public int DocumentTypeId { get; set; }
    }
}
