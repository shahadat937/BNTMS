using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands
{
    public class CreateGuestSpeakerActionStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateGuestSpeakerActionStatusDto GuestSpeakerActionStatusDto { get; set; }
    }
}
