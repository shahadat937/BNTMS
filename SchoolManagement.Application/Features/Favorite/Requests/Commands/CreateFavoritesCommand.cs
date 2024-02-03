using MediatR;
using SchoolManagement.Application.DTOs.Favorites;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Favorite.Requests.Commands
{
    public class CreateFavoritesCommand : IRequest<BaseCommandResponse> 
    {
        public CreateFavoritesDto FavoritesDto { get; set; }      

    }
}
