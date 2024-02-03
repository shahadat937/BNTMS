using MediatR;

namespace SchoolManagement.Application.Features.GameSports.Requests.Commands
{
    public class DeleteGameSportCommand : IRequest
    {
        public int GameSportId { get; set; }
    }
}
