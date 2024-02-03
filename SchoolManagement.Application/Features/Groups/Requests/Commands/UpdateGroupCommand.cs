using MediatR;
using SchoolManagement.Application.DTOs.Groups;

namespace SchoolManagement.Application.Features.Groups.Requests.Commands
{
    public class UpdateGroupCommand : IRequest<Unit>  
    { 
        public GroupDto GroupDto { get; set; }     
    }
}
