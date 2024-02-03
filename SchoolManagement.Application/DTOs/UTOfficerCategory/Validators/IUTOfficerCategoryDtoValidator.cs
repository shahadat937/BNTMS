using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerCategory.Validators
{
    public class IUtofficerCategoryDtoValidator : AbstractValidator<IUtofficerCategoryDto>
    {
        public IUtofficerCategoryDtoValidator()
        {
            RuleFor(p => p.UtofficerCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
    }
}
