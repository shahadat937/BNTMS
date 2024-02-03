using MediatR;

namespace SchoolManagement.Application.Features.Events.Requests.Commands
{
    public class ChangeEventStatusCommand : IRequest
    {
        public int EventId { get; set; }
        public int Status { get; set; }
    }
}
