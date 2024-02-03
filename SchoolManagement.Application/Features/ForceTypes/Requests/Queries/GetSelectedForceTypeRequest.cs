using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Queries
{
    public class GetSelectedForceTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
