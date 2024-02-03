using MediatR;
using SchoolManagement.Application.DTOs.Games;

namespace SchoolManagement.Application.Features.Games.Requests.Queries
{
    public class GetGameDetailRequest : IRequest<GameDto> 
    {
        public int Id { get; set; } 
    }
}
