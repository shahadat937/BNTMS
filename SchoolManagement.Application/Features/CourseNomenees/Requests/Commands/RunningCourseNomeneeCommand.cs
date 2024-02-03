using MediatR;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{
    public class RunningCourseNomeneeCommand : IRequest
    {
        public int CourseNomeneeId { get; set; }  
    }
}
 