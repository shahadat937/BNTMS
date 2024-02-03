using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries
{
    public class GetGuestSpeakerActionStatusDetailRequest : IRequest<GuestSpeakerActionStatusDto>
    {
        public int GuestSpeakerActionStatusId { get; set; }
    }
}
