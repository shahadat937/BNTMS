using SchoolManagement.Application.DTOs.GameSport;
using MediatR;

namespace SchoolManagement.Application.Features.GameSports.Requests.Queries
{
    public class GetGameSportDetailRequest : IRequest<GameSportDto>
    {
        public int GameSportId { get; set; }
    }
}
