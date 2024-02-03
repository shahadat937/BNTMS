using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands
{
    public class UpdateGuestSpeakerQuestionNameCommand : IRequest<Unit>
    {
        public GuestSpeakerQuestionNameDto GuestSpeakerQuestionNameDto { get; set; }
    }
}
