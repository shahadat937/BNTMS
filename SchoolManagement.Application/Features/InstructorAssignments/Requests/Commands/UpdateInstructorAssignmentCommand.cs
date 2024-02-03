using MediatR;
using SchoolManagement.Application.DTOs.InstructorAssignments;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands
{
    public class UpdateInstructorAssignmentCommand : IRequest<Unit>
    {
        public InstructorAssignmentDto InstructorAssignmentDto { get; set; }
    }
}
