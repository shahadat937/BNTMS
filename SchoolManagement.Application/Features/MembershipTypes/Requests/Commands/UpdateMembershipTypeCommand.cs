using MediatR;
using SchoolManagement.Application.DTOs.MembershipTypes;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Commands
{
    public class UpdateMembershipTypeCommand : IRequest<Unit>  
    { 
        public MembershipTypeDto MembershipTypeDto { get; set; }     
    }
}
