using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Branch.Validators
{
    public class IBranchDtoValidator : AbstractValidator<IBranchDto>
    {
        public IBranchDtoValidator()
        {
            RuleFor(p => p.BranchName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
