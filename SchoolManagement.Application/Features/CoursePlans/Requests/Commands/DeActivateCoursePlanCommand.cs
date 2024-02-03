using MediatR;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Commands
{
    public class DeActivateCoursePlanCommand : IRequest
    {
        public int CoursePlanCreateId { get; set; } 
    }
}
