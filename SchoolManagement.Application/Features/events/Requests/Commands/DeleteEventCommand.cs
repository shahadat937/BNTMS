using MediatR;

namespace SchoolManagement.Application.Features.Events.Requests.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public int EventId { get; set; }
    }
}
 