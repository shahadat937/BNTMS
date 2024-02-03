using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries
{
    public class GetSelectedInterServiceMarkRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  