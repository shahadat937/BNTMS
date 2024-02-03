using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries
{
    public class GetSelectedColorOfEyeRequest : IRequest<List<SelectedModel>>
    {
    }
}
      