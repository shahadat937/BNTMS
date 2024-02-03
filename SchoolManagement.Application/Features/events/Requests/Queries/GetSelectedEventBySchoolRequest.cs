using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.Event;

namespace SchoolManagement.Application.Features.Events.Requests.Queries
{
    public class GetSelectedEventBySchoolRequest : IRequest<List<EventDto>>
    {
        public int BaseSchoolNameId { get; set; }
    }
}

  