using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Queries
{
    public class GetSelectedSaylorRankRequest : IRequest<List<SelectedModel>>
    {
    }
}
