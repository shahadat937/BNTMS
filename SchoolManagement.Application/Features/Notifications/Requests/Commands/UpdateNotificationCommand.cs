using MediatR;
using SchoolManagement.Application.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Notifications.Requests.Commands
{
    public class UpdateNotificationCommand : IRequest<Unit>
    {
        public NotificationDto NotificationDto { get; set; }
    }
}
