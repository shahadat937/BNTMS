using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CovidVaccines.Requests.Queries
{
    public class GetSelectedCovidVaccineRequest : IRequest<List<SelectedModel>>
    {
    }
}
