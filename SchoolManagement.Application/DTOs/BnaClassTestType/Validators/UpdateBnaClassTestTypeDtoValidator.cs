using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation; 

namespace SchoolManagement.Application.DTOs.BnaClassTestType.Validators
{
    
    public class UpdateBnaClassTestTypeDtoValidator : AbstractValidator<BnaClassTestTypeDto>
        {
        public UpdateBnaClassTestTypeDtoValidator()
        {
            Include(new IBnaClassTestTypeDtoValidator());

            RuleFor(p => p.BnaClassTestTypeId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
