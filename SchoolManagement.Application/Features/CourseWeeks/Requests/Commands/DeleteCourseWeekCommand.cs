using MediatR;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Commands
{
    public class DeleteCourseWeekCommand : IRequest
    {
        public int CourseWeekId { get; set; }
    }
}
