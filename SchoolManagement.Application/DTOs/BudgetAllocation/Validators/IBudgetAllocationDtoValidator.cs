using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetAllocation.Validators
{
    public class IBudgetAllocationDtoValidator : AbstractValidator<IBudgetAllocationDto>
    {
        public IBudgetAllocationDtoValidator()
        {
            //RuleFor(p => p.BudgetAllocationName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
