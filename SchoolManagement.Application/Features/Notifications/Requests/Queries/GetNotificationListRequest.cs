using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Notifications.Requests.Queries
{
   public class GetNotificationListRequest : IRequest<PagedResult<NotificationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
