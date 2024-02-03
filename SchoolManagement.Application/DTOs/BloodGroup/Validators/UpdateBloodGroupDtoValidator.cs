using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BloodGroup.Validators
{
    
    public class UpdateBloodGroupDtoValidator : AbstractValidator<BloodGroupDto>
        {
        public UpdateBloodGroupDtoValidator()
        {
            Include(new IBloodGroupDtoValidator()); 

            RuleFor(p => p.BloodGroupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
