using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries
{
    public class GetGuestSpeakerListRequest : IRequest<PagedResult<GuestSpeakerQuestionNameDto>> 
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}  
 
  