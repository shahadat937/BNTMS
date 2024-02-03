using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SwimmingDriving.Validators
{
    public class ISwimmingDrivingDtoValidator : AbstractValidator<ISwimmingDrivingDto>
    {
        public ISwimmingDrivingDtoValidator()
        {
            

            RuleFor(p => p.TraineeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            
            RuleFor(p => p.AdditionalInformation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            

        }
    }
}
