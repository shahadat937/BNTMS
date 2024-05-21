using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseTerm.Validators
{
    public class ICourseTermDtoValidator : AbstractValidator<ICourseTermDto>
    {
        public ICourseTermDtoValidator()
        { 
            RuleFor(p => p.CourseTermTitle)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
