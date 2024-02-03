using MediatR;
using SchoolManagement.Application.DTOs.MigrationDocument;

namespace SchoolManagement.Application.Features.MigrationDocuments.Requests.Queries
{
    public class GetMigrationDocumentDetailRequest : IRequest<MigrationDocumentDto> 
    {
        public int Id { get; set; } 
    }
}
