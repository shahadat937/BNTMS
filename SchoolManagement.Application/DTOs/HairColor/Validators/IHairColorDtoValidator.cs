using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HairColor.Validators
{
    public class IHairColorDtoValidator : AbstractValidator<IHairColorDto>
    {
        public IHairColorDtoValidator()
        {
            RuleFor(c => c.HairColorName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
