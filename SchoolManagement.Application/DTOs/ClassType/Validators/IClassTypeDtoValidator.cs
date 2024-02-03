using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ClassType.Validators
{
    public class IClassTypeDtoValidator : AbstractValidator<IClassTypeDto>
    {
        public IClassTypeDtoValidator()
        {
            RuleFor(b => b.ClassTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
