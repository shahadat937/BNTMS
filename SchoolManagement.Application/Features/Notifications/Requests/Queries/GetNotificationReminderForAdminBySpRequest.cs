using MediatR;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
    public class GetNotificationReminderForAdminBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        public string? UserRole { get; set; }
    }
}
