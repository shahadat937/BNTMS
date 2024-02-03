using MediatR;
using SchoolManagement.Application.DTOs.Event;

namespace SchoolManagement.Application.Features.Events.Requests.Queries
{
    public class GetEventDetailRequest : IRequest<EventDto>
    {
        public int EventId { get; set; }
    }
}
 