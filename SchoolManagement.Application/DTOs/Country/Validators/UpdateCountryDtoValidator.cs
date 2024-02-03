using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Country.Validators
{
    public class UpdateCountryDtoValidator : AbstractValidator<CountryDto>
    {
        public UpdateCountryDtoValidator()
        {
            Include(new ICountryDtoValidator());

            RuleFor(c => c.CountryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
