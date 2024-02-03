using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Queries
{
    public class GetSelectedNewAtemptRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  