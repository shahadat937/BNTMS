using MediatR;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class ChangeReceivedStatusCommand : IRequest
    {
        public int CourseBudgetAllocationId { get; set; } 
        public int ReceivedStatus { get; set; }
    }
} 
