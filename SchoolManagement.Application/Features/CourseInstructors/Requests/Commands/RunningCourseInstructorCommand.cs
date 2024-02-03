using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Commands
{
    public class RunningCourseInstructorCommand : IRequest
    {
        public int CourseInstructorId { get; set; }  
    }
}
 