using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.CourseWeeks.Validators
{
    public class UpdateCourseWeekDtoValidator : AbstractValidator<CourseWeekAllDto>
    {
        public UpdateCourseWeekDtoValidator()
        {
            Include(new ICourseWeekDtoValidator());

            RuleFor(b => b.CourseWeekId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

