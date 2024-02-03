using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Divisions.Requests.Queries
{
    public class GetSelectedDivisionRequest : IRequest<List<SelectedModel>>
    {
    }
}
