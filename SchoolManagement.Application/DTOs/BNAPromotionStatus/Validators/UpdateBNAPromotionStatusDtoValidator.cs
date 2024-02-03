using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaPromotionStatus.Validators
{
    
    public class UpdateBnaPromotionStatusDtoValidator : AbstractValidator<BnaPromotionStatusDto>
        { 
        public UpdateBnaPromotionStatusDtoValidator()
        {
            Include(new IBnaPromotionStatusDtoValidator());

            RuleFor(p => p.BnaPromotionStatusId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
