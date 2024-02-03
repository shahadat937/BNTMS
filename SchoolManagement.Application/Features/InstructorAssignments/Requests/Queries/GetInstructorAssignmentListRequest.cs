using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetInstructorAssignmentListRequest : IRequest<PagedResult<InstructorAssignmentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
