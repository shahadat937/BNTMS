using MediatR;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Commands
{
    public class CreateRoutineNoteCommand : IRequest<BaseCommandResponse>
    {
        public CreateRoutineNoteDto RoutineNoteDto { get; set; }
    }
}
