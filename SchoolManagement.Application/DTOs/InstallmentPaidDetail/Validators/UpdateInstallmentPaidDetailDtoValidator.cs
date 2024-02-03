using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstallmentPaidDetail.Validators
{
    public class UpdateInstallmentPaidDetailDtoValidator : AbstractValidator<InstallmentPaidDetailDto>
    {
        public UpdateInstallmentPaidDetailDtoValidator()
        {
            Include(new IInstallmentPaidDetailDtoValidator());

            RuleFor(p => p.InstallmentPaidDetailId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
