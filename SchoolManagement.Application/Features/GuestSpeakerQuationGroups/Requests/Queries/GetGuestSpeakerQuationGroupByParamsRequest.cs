using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using MediatR;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries
{
    public class GetGuestSpeakerQuationGroupByParamsRequest : IRequest<List<GuestSpeakerQuationGroupDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}
