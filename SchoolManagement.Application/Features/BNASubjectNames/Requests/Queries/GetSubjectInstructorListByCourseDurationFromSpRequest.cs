using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetSubjectInstructorListByCourseDurationFromSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
 