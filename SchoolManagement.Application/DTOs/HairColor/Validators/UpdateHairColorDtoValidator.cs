using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HairColor.Validators
{
    public class UpdateHairColorDtoValidator : AbstractValidator<HairColorDto>
    {
        public UpdateHairColorDtoValidator()
        {
            Include(new IHairColorDtoValidator());

            RuleFor(c => c.HairColorName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
