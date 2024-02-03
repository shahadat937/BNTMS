using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CovidVaccine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Queries
{
    public class GetCovidVaccineDetailRequest : IRequest<CovidVaccineDto>
    {
        public int CovidVaccineId { get; set; }
    }
}
