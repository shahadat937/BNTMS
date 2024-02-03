using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnDoc;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries
{
    public class GetWithdrawnDocsDetailRequest : IRequest<WithdrawnDocDto> 
    {
        public int Id { get; set; } 
    }
}
