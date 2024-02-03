using MediatR;
using SchoolManagement.Application.DTOs.InstructorAssignments;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetInstructorAssignmentDetailRequest : IRequest<InstructorAssignmentDto>
    {
        public int InstructorAssignmentId { get; set; }
    }
}
