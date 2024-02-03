using MediatR;
using SchoolManagement.Application.DTOs.MembershipTypes;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Queries
{
    public class GetMembershipTypeDetailRequest : IRequest<MembershipTypeDto> 
    {
        public int Id { get; set; } 
    }
}
