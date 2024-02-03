using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Queries
{
    public class GetSelectedComplexionRequest : IRequest<List<SelectedModel>>
    {
    }
}
   