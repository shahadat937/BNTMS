using MediatR;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Queries
{
    public class GetCovidVaccineListByPnoRequest : IRequest<List<CovidVaccineDto>>
    {
        public int TraineeId { get; set; }
       
    }
}

