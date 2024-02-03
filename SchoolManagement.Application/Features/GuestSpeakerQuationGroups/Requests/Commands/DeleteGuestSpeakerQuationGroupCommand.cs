using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands
{
    public class DeleteGuestSpeakerQuationGroupCommand : IRequest
    {
        public int GuestSpeakerQuationGroupId { get; set; }
    }
}
