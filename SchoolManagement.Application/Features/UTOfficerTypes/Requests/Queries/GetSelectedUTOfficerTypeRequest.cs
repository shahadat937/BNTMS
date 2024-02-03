using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries
{
    public class GetSelectedUtofficerTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
  