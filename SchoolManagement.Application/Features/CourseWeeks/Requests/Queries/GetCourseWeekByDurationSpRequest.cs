using MediatR;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetCourseWeekByDurationSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
