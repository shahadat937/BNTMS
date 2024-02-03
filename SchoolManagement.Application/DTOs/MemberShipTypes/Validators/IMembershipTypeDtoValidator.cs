using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MembershipTypes.Validators
{
    public class IMembershipTypeDtoValidator : AbstractValidator<IMembershipTypeDto>
    {
        public IMembershipTypeDtoValidator()
        {
            RuleFor(p => p.MembershipTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
