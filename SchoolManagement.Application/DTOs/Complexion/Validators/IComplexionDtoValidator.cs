using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Complexion.Validators
{
    public class IComplexionDtoValidator : AbstractValidator<IComplexionDto>
    {
        public IComplexionDtoValidator()
        {
            RuleFor(p => p.ComplexionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
