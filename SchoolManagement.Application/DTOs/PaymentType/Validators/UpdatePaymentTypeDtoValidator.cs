using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentType.Validators
{
    public class UpdatePaymentTypeDtoValidator : AbstractValidator<PaymentTypeDto>
    {
        public UpdatePaymentTypeDtoValidator()
        {
            Include(new IPaymentTypeDtoValidator());

            RuleFor(p => p.PaymentTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
