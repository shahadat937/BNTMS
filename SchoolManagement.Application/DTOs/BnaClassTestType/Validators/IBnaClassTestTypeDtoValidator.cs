using System;
using System.Collections.Generic;
using System.Text; 
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassTestType.Validators
{
    public class IBnaClassTestTypeDtoValidator : AbstractValidator<IBnaClassTestTypeDto>
    {
        public IBnaClassTestTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Propertyname} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
