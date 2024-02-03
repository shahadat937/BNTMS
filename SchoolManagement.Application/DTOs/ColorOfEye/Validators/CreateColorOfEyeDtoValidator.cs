using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ColorOfEye.Validators
{
    public class CreateColorOfEyeDtoValidator : AbstractValidator<CreateColorOfEyeDto>
    {
        public CreateColorOfEyeDtoValidator()
        {
            Include(new IColorOfEyeDtoValidator());
        }
    }
}
