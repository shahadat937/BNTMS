using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaInstructorType.Validators
{ 
    public class IBnaInstructorTypeDtoValidator : AbstractValidator<IBnaInstructorTypeDto>
    {
        public IBnaInstructorTypeDtoValidator()
        {
            RuleFor(p => p.InstructorTypeName)
                .NotEmpty().WithMessage("{Propertyname} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
