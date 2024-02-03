using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseName.Validators
{
    public class ICourseNameDtoValidator : AbstractValidator<ICourseNameDto>
    {
        public ICourseNameDtoValidator()
        {
            //RuleFor(p => p.Course)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
