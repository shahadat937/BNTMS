using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Games.Requests.Queries
{
    public class GetSelectedGameRequest : IRequest<List<SelectedModel>>
    {
    }
}
