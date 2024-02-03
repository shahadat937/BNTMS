using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands
{
    public class CreateGuestSpeakerQuestionNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateGuestSpeakerQuestionNameDto GuestSpeakerQuestionNameDto { get; set; }
    }
}
