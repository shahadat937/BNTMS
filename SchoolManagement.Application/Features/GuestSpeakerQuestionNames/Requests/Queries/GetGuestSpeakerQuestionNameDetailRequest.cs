using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries
{
    public class GetGuestSpeakerQuestionNameDetailRequest : IRequest<GuestSpeakerQuestionNameDto>
    {
        public int GuestSpeakerQuestionNameId { get; set; }
    }
}
