using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassPeriod.Validators
{
    public class UpdateClassPeriodDtoValidator : AbstractValidator<ClassPeriodDto>
    {
        public UpdateClassPeriodDtoValidator()
        {
            Include(new IClassPeriodDtoValidator());

            RuleFor(c => c.PeriodName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
