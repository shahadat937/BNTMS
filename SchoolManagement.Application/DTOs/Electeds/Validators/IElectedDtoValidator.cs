using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Electeds.Validators
{
    public class IElectedDtoValidator : AbstractValidator<IElectedDto>
    {
        public IElectedDtoValidator() 
        {
            RuleFor(p => p.ElectedType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
