using MediatR;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands
{
    public class CreateMigrationDocumentCommand : IRequest<BaseCommandResponse> 
    {
        public CreateMigrationDocumentDto MigrationDocumentDto { get; set; }       

    }
}
