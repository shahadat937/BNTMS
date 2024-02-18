using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.CourseWeeks.Validators
{
    public class ICourseWeekDtoValidator : AbstractValidator<ICourseWeekAllDto>
    {
        public ICourseWeekDtoValidator() 
        {
            RuleFor(b => b.WeekName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
