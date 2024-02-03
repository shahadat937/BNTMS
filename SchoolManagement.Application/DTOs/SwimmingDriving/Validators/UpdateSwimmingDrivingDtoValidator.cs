using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.SwimmingDriving.Validators
{
    public class UpdateSwimmingDrivingDtoValidator : AbstractValidator<SwimmingDrivingDto>
    {
        public UpdateSwimmingDrivingDtoValidator()
        {
            Include(new ISwimmingDrivingDtoValidator());

            RuleFor(p => p.SwimmingDrivingId).NotNull().WithMessage("{PropertyName} must be present");

           
        }
    }
}
