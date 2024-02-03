using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Notification.Validators
{
    public class INotificationDtoValidator : AbstractValidator<INotificationDto>
    {
        public INotificationDtoValidator()
        {
            //RuleFor(b => b.Notes)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
