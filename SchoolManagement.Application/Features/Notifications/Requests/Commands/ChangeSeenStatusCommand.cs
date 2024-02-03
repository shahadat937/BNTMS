using MediatR;

namespace SchoolManagement.Application.Features.Notifications.Requests.Commands
{
    public class ChangeSeenStatusCommand : IRequest
    {
        public int NotificationId { get; set; }
        public int Status { get; set; }
    }
}
