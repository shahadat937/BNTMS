using MediatR;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Notifications.Requests.Commands
{
    public class CreateNotificationCommand : IRequest<BaseCommandResponse>
    {
        public CreateNotificationDto NotificationDto { get; set; }
    }
}
