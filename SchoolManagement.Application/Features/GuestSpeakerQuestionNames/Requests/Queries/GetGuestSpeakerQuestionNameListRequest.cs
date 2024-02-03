using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries
{
   public class GetGuestSpeakerQuestionNameListRequest : IRequest<PagedResult<GuestSpeakerQuestionNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
