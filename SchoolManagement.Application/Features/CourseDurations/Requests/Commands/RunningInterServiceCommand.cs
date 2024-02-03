using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class RunningInterServiceCommand : IRequest
    {
        public int CourseDurationId { get; set; }  
    }
}
 