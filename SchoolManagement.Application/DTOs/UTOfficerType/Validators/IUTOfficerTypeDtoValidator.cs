using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerType.Validators
{
    public class IUtofficerTypeDtoValidator : AbstractValidator<IUtofficerTypeDto>
    {
        public IUtofficerTypeDtoValidator()
        {
            RuleFor(p => p.UtofficerTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

           
        }
    }
}
