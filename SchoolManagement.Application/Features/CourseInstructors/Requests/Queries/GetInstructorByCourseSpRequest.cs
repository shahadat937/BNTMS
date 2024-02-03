using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorByCourseSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
