using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class DeActivateCourseDurationCommand : IRequest 
    {
        public int CourseDurationId { get; set; } 
    }
}
 