using MediatR;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands
{
    public class CreateInstructorAssignmentCommand : IRequest<BaseCommandResponse>
    {
        public CreateInstructorAssignmentDto InstructorAssignmentDto { get; set; }
    }
}
