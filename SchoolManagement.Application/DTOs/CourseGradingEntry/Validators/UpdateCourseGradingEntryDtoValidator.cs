using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseGradingEntry.Validators
{
    public class UpdateCourseGradingEntryDtoValidator : AbstractValidator<CourseGradingEntryDto>
    {
        public UpdateCourseGradingEntryDtoValidator()
        {
            Include(new ICourseGradingEntryDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
