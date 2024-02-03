using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Heights.Requests.Queries
{
    public class GetSelectedHeightRequest : IRequest<List<SelectedModel>>
    {
    }
}
   