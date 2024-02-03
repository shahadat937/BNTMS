using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CovidVaccine.Validators
{
    public class UpdateCovidVaccineDtoValidator : AbstractValidator<CovidVaccineDto>
    {
        public UpdateCovidVaccineDtoValidator()
        {
            Include(new ICovidVaccineDtoValidator());

            RuleFor(p => p.CovidVaccineId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
