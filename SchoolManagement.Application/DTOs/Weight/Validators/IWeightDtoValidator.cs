using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Weight.Validators
{
    public class IWeightDtoValidator : AbstractValidator<IWeightDto>
    {
        public IWeightDtoValidator()
        {
            RuleFor(p => p.WeightName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
