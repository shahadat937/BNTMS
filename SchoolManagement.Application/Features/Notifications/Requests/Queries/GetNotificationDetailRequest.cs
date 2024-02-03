using MediatR;
using SchoolManagement.Application.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
    public class GetNotificationDetailRequest : IRequest<NotificationDto>
    {
        public int NotificationId { get; set; }
    }
}
