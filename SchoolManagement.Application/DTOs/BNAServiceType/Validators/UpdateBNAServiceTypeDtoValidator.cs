using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation; 

namespace SchoolManagement.Application.DTOs.BnaServiceType.Validators
{
    
    public class UpdateBnaServiceTypeDtoValidator : AbstractValidator<BnaServiceTypeDto>
        {
        public UpdateBnaServiceTypeDtoValidator()
        {
            Include(new IBnaServiceTypeDtoValidator());

            RuleFor(p => p.BnaServiceTypeId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
