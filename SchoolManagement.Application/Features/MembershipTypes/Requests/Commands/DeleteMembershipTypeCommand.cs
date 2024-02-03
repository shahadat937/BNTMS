using MediatR;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Commands
{
    public class DeleteMembershipTypeCommand : IRequest 
    {  
        public int Id { get; set; } 
    }
}
