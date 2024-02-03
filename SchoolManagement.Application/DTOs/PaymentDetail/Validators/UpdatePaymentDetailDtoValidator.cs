using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentDetail.Validators
{
    public class UpdatePaymentDetailDtoValidator : AbstractValidator<PaymentDetailDto>
    {
        public UpdatePaymentDetailDtoValidator()
        {
            Include(new IPaymentDetailDtoValidator());

            RuleFor(p => p.PaymentDetailId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
