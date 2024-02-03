using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetUpcomingCourseListByTypeFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
