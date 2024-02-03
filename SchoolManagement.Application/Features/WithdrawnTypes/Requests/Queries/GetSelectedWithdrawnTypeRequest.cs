using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries
{
    public class GetSelectedWithdrawnTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  