using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ColorOfEye.Validators
{
    public class UpdateColorOfEyeDtoValidator : AbstractValidator<ColorOfEyeDto>
    {
        public UpdateColorOfEyeDtoValidator()
        {
            Include(new IColorOfEyeDtoValidator());

            RuleFor(b => b.ColorOfEyeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
