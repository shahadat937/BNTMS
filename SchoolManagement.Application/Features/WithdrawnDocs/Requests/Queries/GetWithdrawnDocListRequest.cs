using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries
{
    public class GetWithdrawnDocsListRequest : IRequest<PagedResult<WithdrawnDocDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
