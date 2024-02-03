using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SwimmingDrivingLevel.Validators
{
    public class CreateSwimmingDrivingLevelDtoValidator : AbstractValidator<CreateSwimmingDrivingLevelDto>
    {
        public CreateSwimmingDrivingLevelDtoValidator()
        {
            Include(new ISwimmingDrivingLevelDtoValidator());
        }
    }
}
