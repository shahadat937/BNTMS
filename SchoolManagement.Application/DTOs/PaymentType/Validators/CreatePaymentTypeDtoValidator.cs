using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentType.Validators
{
    public class CreatePaymentTypeDtoValidator : AbstractValidator<CreatePaymentTypeDto>
    {
        public CreatePaymentTypeDtoValidator()
        {
            Include(new IPaymentTypeDtoValidator());
        }
    }
}
