using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands
{
    public class UpdateGuestSpeakerQuationGroupCommand : IRequest<Unit>
    {
        public GuestSpeakerQuationGroupDto GuestSpeakerQuationGroupDto { get; set; }
    }
}
