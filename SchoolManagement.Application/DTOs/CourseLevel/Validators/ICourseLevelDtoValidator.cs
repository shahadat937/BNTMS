using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseLevel.Validators
{
    public class ICourseLevelDtoValidator : AbstractValidator<ICourseLevelDto>
    {
        public ICourseLevelDtoValidator()
        { 
            RuleFor(p => p.CourseLeveTitle)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
