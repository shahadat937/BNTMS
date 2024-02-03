using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Queries
{
    public class GetAssignmentMarkEntryListRequest : IRequest<PagedResult<AssignmentMarkEntryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
