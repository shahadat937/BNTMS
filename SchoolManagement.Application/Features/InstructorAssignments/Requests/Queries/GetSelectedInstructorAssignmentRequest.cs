using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetSelectedInstructorAssignmentRequest : IRequest<List<SelectedModel>>
    {
    }
}
