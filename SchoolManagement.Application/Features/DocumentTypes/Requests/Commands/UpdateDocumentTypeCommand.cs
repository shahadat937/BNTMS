using MediatR;
using SchoolManagement.Application.DTOs.DocumentTypes;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Commands
{
    public class UpdateDocumentTypeCommand : IRequest<Unit>
    {
        public DocumentTypeDto DocumentTypeDto { get; set; } 
    }
}
