using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentDetail.Validators
{
    public class CreatePaymentDetailDtoValidator : AbstractValidator<CreatePaymentDetailDto>
    {
        public CreatePaymentDetailDtoValidator()
        {
            Include(new IPaymentDetailDtoValidator());
        }
    }
}
