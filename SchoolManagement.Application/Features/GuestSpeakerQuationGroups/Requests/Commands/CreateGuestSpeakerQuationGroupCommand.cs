using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.CreateGuestSpeakerQuationGroup;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands
{
    public class CreateGuestSpeakerQuationGroupCommand : IRequest<BaseCommandResponse>
    { 
        public CreateGuestSpeakerQuationGroupDto GuestSpeakerQuationGroupDto { get; set; }
    }
}
