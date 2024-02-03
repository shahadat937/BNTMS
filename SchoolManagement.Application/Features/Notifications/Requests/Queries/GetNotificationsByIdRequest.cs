using MediatR;
using SchoolManagement.Application.DTOs.Notification;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
    public class GetNotificationsByIdRequest : IRequest<List<NotificationDto>>
    {        
        public string? UserRole { get; set; }
        public int? SenderId { get; set; }
        public int? ReciverId { get; set; }
    }
}

 