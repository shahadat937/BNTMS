using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoursePlan.Validators
{
    public class ICoursePlanDtoValidator : AbstractValidator<ICoursePlanDto>
    {
        public ICoursePlanDtoValidator()
        {
            //RuleFor(c => c.CoursePlanName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    } 
}
