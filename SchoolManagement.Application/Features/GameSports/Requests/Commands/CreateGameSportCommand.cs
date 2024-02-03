using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.GameSports.Requests.Commands
{
    public class CreateGameSportCommand : IRequest<BaseCommandResponse>
    {
        public CreateGameSportDto GameSportDto { get; set; }

    }
}
