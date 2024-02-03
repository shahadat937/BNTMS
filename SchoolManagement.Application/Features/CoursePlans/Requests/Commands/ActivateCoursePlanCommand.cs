using MediatR;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Commands
{
    public class ActivateCoursePlanCommand : IRequest
    {
        public int CoursePlanCreateId { get; set; } 
    }
}
