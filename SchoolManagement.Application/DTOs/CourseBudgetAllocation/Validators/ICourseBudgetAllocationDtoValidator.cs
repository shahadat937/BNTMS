using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseBudgetAllocation.Validators
{
    public class ICourseBudgetAllocationDtoValidator : AbstractValidator<ICourseBudgetAllocationDto>
    {
        public ICourseBudgetAllocationDtoValidator()
        {
            //RuleFor(p => p.CourseBudgetAllocationName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
