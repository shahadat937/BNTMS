using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MigrationDocuments.Requests.Queries
{
    public class GetMigrationDocumentListRequest : IRequest<PagedResult<MigrationDocumentDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
