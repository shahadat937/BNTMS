using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetType.Validators
{
    public class IBudgetTypeDtoValidator : AbstractValidator<IBudgetTypeDto>
    {
        public IBudgetTypeDtoValidator()
        {
            RuleFor(b => b.BudgetTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
