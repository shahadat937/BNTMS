using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CovidVaccine;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Commands
{
    public class UpdateCovidVaccineCommand : IRequest<Unit>
    {
        public CovidVaccineDto CovidVaccineDto { get; set; } 

    }
}
