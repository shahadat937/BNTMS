using MediatR;

namespace SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands
{
    public class DeleteMigrationDocumentCommand : IRequest 
    {  
        public int Id { get; set; } 
    }
}
