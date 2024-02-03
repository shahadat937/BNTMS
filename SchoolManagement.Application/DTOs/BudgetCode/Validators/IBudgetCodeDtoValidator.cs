using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetCode.Validators
{
    public class IBudgetCodeDtoValidator : AbstractValidator<IBudgetCodeDto>
    {
        public IBudgetCodeDtoValidator()
        {
            RuleFor(b => b.BudgetCodes)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
