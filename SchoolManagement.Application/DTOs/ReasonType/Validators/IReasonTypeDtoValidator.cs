
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReasonType.Validators
{
    public class IReasonTypeDtoValidator : AbstractValidator<IReasonTypeDto>
    {
        public IReasonTypeDtoValidator()
        {
            RuleFor(b => b.ReasonTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
