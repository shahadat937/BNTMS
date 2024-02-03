using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnDoc;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands
{
    public class UpdateWithdrawnDocCommand : IRequest<Unit>  
    { 
        public WithdrawnDocDto WithdrawnDocDto { get; set; }     
    }
}
