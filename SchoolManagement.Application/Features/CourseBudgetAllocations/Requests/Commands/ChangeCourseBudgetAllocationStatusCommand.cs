using MediatR;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class ChangeCourseBudgetAllocationStatusCommand : IRequest
    {
        public int CourseBudgetAllocationId { get; set; } 
        public int Status { get; set; }
    }
} 
