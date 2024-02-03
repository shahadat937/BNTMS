using MediatR;

namespace SchoolManagement.Application.Features.Events.Requests.Queries
{
    public class GetEventBySchoolIdSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
