using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Height.Validators
{
    public class IHeightDtoValidator : AbstractValidator<IHeightDto>
    {
        public IHeightDtoValidator()
        {
            RuleFor(p => p.HeightName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
