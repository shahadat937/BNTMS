using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Country.Validators
{
    public class ICountryDtoValidator : AbstractValidator<ICountryDto>
    {
        public ICountryDtoValidator()
        {
            RuleFor(c => c.CountryName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
