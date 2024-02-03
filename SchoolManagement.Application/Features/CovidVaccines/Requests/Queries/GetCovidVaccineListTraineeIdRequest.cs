using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CovidVaccine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Queries
{
    public class GetCovidVaccineListTraineeIdRequest : IRequest<List<CovidVaccineDto>>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
    } 
}
