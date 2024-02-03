using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaritalStatus.Validators
{
    public class IMaritalStatusDtoValidator : AbstractValidator<IMaritalStatusDto>
    {
        public IMaritalStatusDtoValidator()
        {
            RuleFor(p => p.MaritalStatusName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
