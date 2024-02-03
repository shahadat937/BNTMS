using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries
{
    public class GetGuestSpeakerQuationGroupDetailRequest : IRequest<GuestSpeakerQuationGroupDto>
    {
        public int GuestSpeakerQuationGroupId { get; set; }
    }
}
