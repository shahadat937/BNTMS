using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands
{
    public class UpdateGuestSpeakerActionStatusCommand : IRequest<Unit>
    {
        public GuestSpeakerActionStatusDto GuestSpeakerActionStatusDto { get; set; }
    }
}
