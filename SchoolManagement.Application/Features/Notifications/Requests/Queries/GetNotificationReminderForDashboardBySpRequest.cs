using MediatR;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
    public class GetNotificationReminderForDashboardBySpRequest : IRequest<object>
    {
        //public int? BaseSchoolNameId { get; set; }
        public string? UserRole { get; set; }
        public int? ReceiverId { get; set; }
    }
}
