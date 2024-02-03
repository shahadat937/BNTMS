using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SwimmingDriving.Validators
{
    public class CreateSwimmingDrivingDtoValidator : AbstractValidator<CreateSwimmingDrivingDto>
    {
        public CreateSwimmingDrivingDtoValidator()
        {
            Include(new ISwimmingDrivingDtoValidator());
        }
    }
}
