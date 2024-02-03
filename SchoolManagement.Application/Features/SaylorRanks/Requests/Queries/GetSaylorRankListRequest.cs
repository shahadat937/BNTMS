using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Queries
{
    public class GetSaylorRankListRequest : IRequest<PagedResult<SaylorRankDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
