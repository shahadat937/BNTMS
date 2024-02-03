using MediatR;

namespace SchoolManagement.Application.Features.Notices.Requests.Queries
{
    public class GetNoticeBySchoolIdSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
