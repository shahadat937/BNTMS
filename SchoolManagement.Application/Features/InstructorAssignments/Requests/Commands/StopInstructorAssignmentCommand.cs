using MediatR;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands
{
    public class StopInstructorAssignmentCommand : IRequest
    {
        public int InstructorAssignmentId { get; set; }  
    }
}
   