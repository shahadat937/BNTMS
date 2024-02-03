using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Queries
{
    public class GetRoutineNoteListRequest : IRequest<PagedResult<RoutineNoteDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
