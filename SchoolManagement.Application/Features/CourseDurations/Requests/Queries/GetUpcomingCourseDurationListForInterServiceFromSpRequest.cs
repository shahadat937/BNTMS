using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetUpcomingCourseDurationListForInterServiceFromSpRequest : IRequest<object>
    {
       
        public int CourseTypeId { get; set; }
        public DateTime? CurrentDate { get; set; }
        //public int ViewStatus { get; set; }
    }
}
