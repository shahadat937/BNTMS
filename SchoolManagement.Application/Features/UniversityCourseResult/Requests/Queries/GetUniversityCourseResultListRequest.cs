using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetUniversityCourseResultListRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
