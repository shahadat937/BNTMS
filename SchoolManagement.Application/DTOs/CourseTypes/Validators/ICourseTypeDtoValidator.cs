using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.CourseTypes.Validators
{
    public class ICourseTypeDtoValidator : AbstractValidator<ICourseTypeDto>
    {
        public ICourseTypeDtoValidator() 
        {
            RuleFor(b => b.CourseTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
