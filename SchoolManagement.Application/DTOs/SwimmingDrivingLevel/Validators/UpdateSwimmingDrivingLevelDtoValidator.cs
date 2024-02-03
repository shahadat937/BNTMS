using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SwimmingDrivingLevel.Validators
{
    public class UpdateSwimmingDrivingLevelDtoValidator : AbstractValidator<SwimmingDrivingLevelDto>
    {
        public UpdateSwimmingDrivingLevelDtoValidator()
        {
            Include(new ISwimmingDrivingLevelDtoValidator());

            RuleFor(p => p.SwimmingDrivingLevelId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.SwimmingDrivingId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
