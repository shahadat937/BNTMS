using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Commands
{
    public class CreateCovidVaccineCommand : IRequest<BaseCommandResponse>
    {
        public CreateCovidVaccineDto CovidVaccineDto { get; set; }

    }
}
