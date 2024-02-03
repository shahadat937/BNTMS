using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Commands
{
    public class DeleteCovidVaccineCommand : IRequest
    {
        public int CovidVaccineId { get; set; }
    }
}
