using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SwimmingDrivingLevel.Validators
{
    public class ISwimmingDrivingLevelDtoValidator : AbstractValidator<ISwimmingDrivingLevelDto>
    {
        public ISwimmingDrivingLevelDtoValidator()
        {
            

            RuleFor(p => p.SwimmingDrivingId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            
        }
    }
}
