using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Queries
{
    public class GetSelectedBnaSemesterRequest : IRequest<List<SelectedModel>>
    {
    }
}
  