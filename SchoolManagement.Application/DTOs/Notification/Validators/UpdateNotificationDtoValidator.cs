using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Notification.Validators
{
    public class UpdateNotificationDtoValidator : AbstractValidator<NotificationDto>
    {
        public UpdateNotificationDtoValidator()
        {
            Include(new INotificationDtoValidator());

            RuleFor(p => p.NotificationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
