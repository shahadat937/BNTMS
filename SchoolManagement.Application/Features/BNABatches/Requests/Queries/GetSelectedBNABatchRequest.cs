using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Queries
{
    public class GetSelectedBnaBatchRequest : IRequest<List<SelectedModel>>
    {
    }
}
  