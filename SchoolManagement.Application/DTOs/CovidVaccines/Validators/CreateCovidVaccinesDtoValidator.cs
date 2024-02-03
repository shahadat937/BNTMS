using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CovidVaccine.Validators
{
    public class CreateCovidVaccineDtoValidator : AbstractValidator<CreateCovidVaccineDto>
    {
        public CreateCovidVaccineDtoValidator()
        {
            Include(new ICovidVaccineDtoValidator());
        }
    }
}
