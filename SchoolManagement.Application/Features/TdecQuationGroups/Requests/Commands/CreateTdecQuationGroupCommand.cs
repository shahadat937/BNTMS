using MediatR;
using SchoolManagement.Application.DTOs.TdecQuationGroup.CreateTdecQuationGroup;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands
{
    public class CreateTdecQuationGroupCommand : IRequest<BaseCommandResponse>
    { 
        public CreateTdecQuationGroupDto TdecQuationGroupDto { get; set; }
    }
}
