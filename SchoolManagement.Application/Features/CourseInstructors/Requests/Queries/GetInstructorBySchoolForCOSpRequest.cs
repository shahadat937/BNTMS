using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorBySchoolForCOSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
    }
}
