using MediatR;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Commands
{
    public class DeleteJoiningReasonCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
