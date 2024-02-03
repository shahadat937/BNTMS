using MediatR;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Commands
{
    public class ChangeCourseWeekStatusCommand : IRequest
    {
        public int CourseWeekId { get; set; }
        public int Status { get; set; }
    }
}
