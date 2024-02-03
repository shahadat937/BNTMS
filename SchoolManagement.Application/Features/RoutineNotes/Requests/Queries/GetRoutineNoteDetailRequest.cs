using MediatR;
using SchoolManagement.Application.DTOs.RoutineNote;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Queries
{
    public class GetRoutineNoteDetailRequest : IRequest<RoutineNoteDto>
    {
        public int RoutineNoteId { get; set; }
    }
}
