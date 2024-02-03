using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstallmentPaidDetail.Validators
{
    public class IInstallmentPaidDetailDtoValidator : AbstractValidator<IInstallmentPaidDetailDto>
    {
        public IInstallmentPaidDetailDtoValidator()
        {
            //RuleFor(p => p.InstallmentPaidDetailName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
