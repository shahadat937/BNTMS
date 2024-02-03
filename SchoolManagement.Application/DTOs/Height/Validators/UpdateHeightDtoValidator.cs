using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Height.Validators
{
    public class UpdateHeightDtoValidator : AbstractValidator<HeightDto>
    {
        public UpdateHeightDtoValidator()
        {
            Include(new IHeightDtoValidator());

            RuleFor(p => p.HeightId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
