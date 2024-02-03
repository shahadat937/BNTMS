using SchoolManagement.Application.DTOs.GameSport;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GameSports.Requests.Queries
{
    public class GetGameSportListRequest : IRequest<PagedResult<GameSportDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
