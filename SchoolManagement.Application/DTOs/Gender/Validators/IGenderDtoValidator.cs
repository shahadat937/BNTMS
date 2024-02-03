using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Gender.Validators
{
    public class IGenderDtoValidator : AbstractValidator<IGenderDto>
    {
        public IGenderDtoValidator()
        {
            RuleFor(p => p.GenderName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

           
        }
    }
}
