using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands
{
    public class DeleteGuestSpeakerActionStatusCommand : IRequest
    {
        public int GuestSpeakerActionStatusId { get; set; }
    }
}
