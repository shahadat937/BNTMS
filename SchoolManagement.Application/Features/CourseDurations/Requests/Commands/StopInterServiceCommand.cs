using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class StopInterServiceCommand : IRequest
    {
        public int CourseDurationId { get; set; }  
    }
}
 