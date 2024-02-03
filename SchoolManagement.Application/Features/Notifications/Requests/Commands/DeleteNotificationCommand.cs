using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Notifications.Requests.Commands
{
    public class DeleteNotificationCommand : IRequest
    {
        public int NotificationId { get; set; }
    }
}
