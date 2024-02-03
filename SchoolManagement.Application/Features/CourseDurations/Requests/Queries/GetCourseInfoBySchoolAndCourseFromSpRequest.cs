using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseInfoBySchoolAndCourseFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
