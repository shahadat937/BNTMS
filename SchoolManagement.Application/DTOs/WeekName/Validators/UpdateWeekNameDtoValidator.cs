using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.WeekName.Validators
{
    public class UpdateWeekNameDtoValidator : AbstractValidator<WeekNameDto>
    {
        public UpdateWeekNameDtoValidator()
        {
            Include(new IWeekNameDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
