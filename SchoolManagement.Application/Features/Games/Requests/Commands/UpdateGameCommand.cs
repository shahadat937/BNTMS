using MediatR;
using SchoolManagement.Application.DTOs.Games;

namespace SchoolManagement.Application.Features.Games.Requests.Commands
{
    public class UpdateGameCommand : IRequest<Unit>  
    { 
        public GameDto GameDto { get; set; }     
    }
}
