using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.GrandFatherType.Validators
{
    public class IGrandFatherTypeDtoValidator : AbstractValidator<IGrandFatherTypeDto>
    {
        public IGrandFatherTypeDtoValidator()
        {
            RuleFor(p => p.GrandfatherTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
