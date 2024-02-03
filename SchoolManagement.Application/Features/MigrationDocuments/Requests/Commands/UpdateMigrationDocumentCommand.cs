using MediatR;
using SchoolManagement.Application.DTOs.MigrationDocument;

namespace SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands
{
    public class UpdateMigrationDocumentCommand : IRequest<Unit>  
    { 
        public MigrationDocumentDto MigrationDocumentDto { get; set; }     
    }
}
