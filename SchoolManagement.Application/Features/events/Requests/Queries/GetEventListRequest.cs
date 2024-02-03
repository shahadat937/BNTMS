using MediatR;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Events.Requests.Queries
{
    public class GetEventListRequest : IRequest<PagedResult<EventDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int? BaseSchoolNameId { get; set; }
    }
}
