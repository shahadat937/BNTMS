using MediatR;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Commands
{
    public class CreateMembershipTypeCommand : IRequest<BaseCommandResponse> 
    {
        public CreateMembershipTypeDto MembershipTypeDto { get; set; }       

    }
}
