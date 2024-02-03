using MediatR;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{
    public class StopCourseNomeneeCommand : IRequest
    {
        public int CourseNomeneeId { get; set; }  
    }
}
 