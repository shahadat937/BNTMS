using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaPromotionStatus.Validators
{
    public class CreateBnaPromotionStatusDtoValidator : AbstractValidator<CreateBnaPromotionStatusDto>
    {
        public CreateBnaPromotionStatusDtoValidator()
        {
            Include(new IBnaPromotionStatusDtoValidator());
        }
    }
}
 