using MediatR;
using SchoolManagement.Application.DTOs.Groups;

namespace SchoolManagement.Application.Features.Groups.Requests.Queries
{
    public class GetGroupsDetailRequest : IRequest<GroupDto> 
    {
        public int Id { get; set; } 
    }
}
