using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class ChangeCourseDurationStatusCommand : IRequest
    {
        public int CourseDurationId { get; set; }
        public int IsCompletedStatus { get; set; }
    }
}
