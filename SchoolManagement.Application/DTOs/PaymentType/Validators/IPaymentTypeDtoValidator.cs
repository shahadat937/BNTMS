using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentType.Validators
{
    public class IPaymentTypeDtoValidator : AbstractValidator<IPaymentTypeDto>
    {
        public IPaymentTypeDtoValidator()
        {
            RuleFor(b => b.PaymentTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
