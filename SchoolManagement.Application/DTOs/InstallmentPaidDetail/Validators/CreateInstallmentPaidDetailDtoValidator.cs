using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InstallmentPaidDetail.Validators
{
    public class CreateInstallmentPaidDetailDtoValidator : AbstractValidator<CreateInstallmentPaidDetailDto>
    {
        public CreateInstallmentPaidDetailDtoValidator()
        {
            Include(new IInstallmentPaidDetailDtoValidator());
        }
    }
}
