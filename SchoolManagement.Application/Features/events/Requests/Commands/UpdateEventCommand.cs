using MediatR;
using SchoolManagement.Application.DTOs.Event;

namespace SchoolManagement.Application.Features.Events.Requests.Commands
{
    public class UpdateEventCommand : IRequest<Unit>
    {
        public EventDto EventDto { get; set; }
    }
} 
