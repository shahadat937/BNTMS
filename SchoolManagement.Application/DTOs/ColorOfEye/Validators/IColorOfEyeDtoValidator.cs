
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ColorOfEye.Validators
{
    public class IColorOfEyeDtoValidator : AbstractValidator<IColorOfEyeDto>
    {
        public IColorOfEyeDtoValidator()
        {
            RuleFor(b => b.ColorOfEyeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
