using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BNASemesters.Requests.Queries
{
    public class GetSelectedRankRequest : IRequest<List<SelectedModel>>
    {
    }
}
  