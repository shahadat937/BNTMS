using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillet.Validators
{
    public class IPresentBilletDtoValidator : AbstractValidator<IPresentBilletDto>
    {
        public IPresentBilletDtoValidator()
        {
            RuleFor(p => p.PresentBilletName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
