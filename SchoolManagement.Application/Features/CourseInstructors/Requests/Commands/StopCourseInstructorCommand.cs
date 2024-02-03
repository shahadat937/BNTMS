using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Commands
{
    public class StopCourseInstructorCommand : IRequest
    {
        public int CourseInstructorId { get; set; }  
    }
}
 