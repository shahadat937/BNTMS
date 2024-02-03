using MediatR;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Events.Requests.Commands
{
    public class CreateEventCommand : IRequest<BaseCommandResponse>
    {
        public CreateEventDto EventDto { get; set; }
    }
}
 