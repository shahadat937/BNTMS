using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaPromotionStatus.Validators
{
    public class IBnaPromotionStatusDtoValidator : AbstractValidator<IBnaPromotionStatusDto>
    {
        public IBnaPromotionStatusDtoValidator() 
        {
            RuleFor(p => p.PromotionStatusName)
                .NotEmpty().WithMessage("{Propertyname} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
