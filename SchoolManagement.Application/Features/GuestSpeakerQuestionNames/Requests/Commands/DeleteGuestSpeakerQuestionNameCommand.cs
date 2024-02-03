using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands
{
    public class DeleteGuestSpeakerQuestionNameCommand : IRequest
    {
        public int GuestSpeakerQuestionNameId { get; set; }
    }
}
