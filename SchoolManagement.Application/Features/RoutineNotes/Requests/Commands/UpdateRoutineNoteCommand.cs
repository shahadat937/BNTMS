using MediatR;
using SchoolManagement.Application.DTOs.RoutineNote;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Commands
{
    public class UpdateRoutineNoteCommand : IRequest<Unit>
    {
        public CreateRoutineNoteDto RoutineNoteDto { get; set; }
    }
}
