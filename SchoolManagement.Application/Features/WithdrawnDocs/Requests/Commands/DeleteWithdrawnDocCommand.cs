using MediatR;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands
{
    public class DeleteWithdrawnDocCommand : IRequest 
    {  
        public int Id { get; set; }
    }
}
