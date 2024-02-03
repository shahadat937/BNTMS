using MediatR;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
    public class GetNotificationResponseListForSchoolBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
    }
}
