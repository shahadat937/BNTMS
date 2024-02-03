using FluentValidation;
using SchoolManagement.Application.DTOs.CovidVaccine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CovidVaccine.Validators
{
    public class ICovidVaccineDtoValidator : AbstractValidator<ICovidVaccineDto>
    {
        public ICovidVaccineDtoValidator()
        {
            //RuleFor(p => p.CovidVaccineName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
