using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetGuestSpeakerQuestionListRequest : IRequest<List<GuestSpeakerQuestionNameDto>> 
    {
        public int BaseSchoolNameId { get; set; }
    }
} 

   