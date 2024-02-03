using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaInstructorType.Validators
{
    
    public class UpdateBnaInstructorTypeDtoValidator : AbstractValidator<BnaInstructorTypeDto>
        {
        public UpdateBnaInstructorTypeDtoValidator()
        {
            Include(new IBnaInstructorTypeDtoValidator());

            RuleFor(p => p.BnaInstructorTypeId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
 