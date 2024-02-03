using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetType.Validators
{
    public class UpdateBudgetTypeDtoValidator : AbstractValidator<BudgetTypeDto>
    {
        public UpdateBudgetTypeDtoValidator()
        {
            Include(new IBudgetTypeDtoValidator());

            RuleFor(p => p.BudgetTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
