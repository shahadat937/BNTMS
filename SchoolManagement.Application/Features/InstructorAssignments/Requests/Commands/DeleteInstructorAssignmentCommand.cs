using MediatR;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands
{
    public class DeleteInstructorAssignmentCommand : IRequest
    {
        public int InstructorAssignmentId { get; set; }
    }
}
