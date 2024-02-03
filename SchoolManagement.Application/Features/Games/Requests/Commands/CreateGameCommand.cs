using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.Games;

namespace SchoolManagement.Application.Features.Games.Requests.Commands
{
    public class CreateGameCommand : IRequest<BaseCommandResponse> 
    {
        public CreateGameDto GameDto { get; set; }      

    }
}
