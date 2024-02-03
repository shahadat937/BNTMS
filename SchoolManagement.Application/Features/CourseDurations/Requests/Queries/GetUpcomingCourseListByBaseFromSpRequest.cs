using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetUpcomingCourseListByBaseFromSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
