using MediatR;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class AcceptedCourseBudgetAllocationCommand : IRequest 
    {
        public int CourseBudgetAllocationId { get; set; } 
    }
}
