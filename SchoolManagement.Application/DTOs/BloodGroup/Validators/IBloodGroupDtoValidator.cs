using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BloodGroup.Validators
{
    public class IBloodGroupDtoValidator : AbstractValidator<IBloodGroupDto>
    {
        public IBloodGroupDtoValidator()
        { 
            RuleFor(p => p.BloodGroupName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
