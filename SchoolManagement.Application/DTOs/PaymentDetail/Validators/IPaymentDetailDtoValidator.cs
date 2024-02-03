using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PaymentDetail.Validators
{
    public class IPaymentDetailDtoValidator : AbstractValidator<IPaymentDetailDto>
    {
        public IPaymentDetailDtoValidator()
        {
            //RuleFor(p => p.PaymentDetailName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
