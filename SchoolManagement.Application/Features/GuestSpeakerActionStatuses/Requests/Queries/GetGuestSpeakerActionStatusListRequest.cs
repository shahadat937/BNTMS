using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries
{
   public class GetGuestSpeakerActionStatusListRequest : IRequest<PagedResult<GuestSpeakerActionStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
