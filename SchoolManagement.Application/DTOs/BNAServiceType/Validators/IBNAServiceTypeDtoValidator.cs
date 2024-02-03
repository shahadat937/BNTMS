using System;
using System.Collections.Generic;
using System.Text; 
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaServiceType.Validators
{
    public class IBnaServiceTypeDtoValidator : AbstractValidator<IBnaServiceTypeDto>
    {
        public IBnaServiceTypeDtoValidator()
        {
            RuleFor(p => p.ServiceName)
                .NotEmpty().WithMessage("{Propertyname} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
