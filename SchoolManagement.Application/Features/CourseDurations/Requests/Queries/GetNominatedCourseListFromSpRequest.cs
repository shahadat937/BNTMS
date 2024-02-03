using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedCourseListFromSpRequest : IRequest<object>
    {        
        public DateTime? CurrentDate { get; set; }
    }
}
