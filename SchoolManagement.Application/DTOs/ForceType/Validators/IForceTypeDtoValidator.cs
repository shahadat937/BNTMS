using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForceType.Validators
{
    public class IForceTypeDtoValidator : AbstractValidator<IForceTypeDto>
    {
        public IForceTypeDtoValidator()
        {
            RuleFor(c => c.ForceTypeName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
