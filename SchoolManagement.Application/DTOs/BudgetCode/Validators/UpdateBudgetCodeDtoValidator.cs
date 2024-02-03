using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetCode.Validators
{
    public class UpdateBudgetCodeDtoValidator : AbstractValidator<BudgetCodeDto>
    {
        public UpdateBudgetCodeDtoValidator()
        {
            Include(new IBudgetCodeDtoValidator());

            RuleFor(p => p.BudgetCodeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
