using MediatR;


namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Commands
{
    public class DeleteRoutineNoteCommand : IRequest
    {
        public int RoutineNoteId { get; set; }
    }
}
