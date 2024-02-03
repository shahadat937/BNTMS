using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.FailureStatus.Validators
{
    public class IFailureStatusDtoValidator : AbstractValidator<IFailureStatusDto>
    {
        public IFailureStatusDtoValidator()
        {
            RuleFor(p => p.FailureStatusName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
