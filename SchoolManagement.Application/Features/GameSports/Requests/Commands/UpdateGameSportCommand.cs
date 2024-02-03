using MediatR;
using SchoolManagement.Application.DTOs.GameSport;

namespace SchoolManagement.Application.Features.GameSports.Requests.Commands
{
    public class UpdateGameSportCommand : IRequest<Unit>
    {
        public GameSportDto GameSportDto { get; set; } 

    }
}
