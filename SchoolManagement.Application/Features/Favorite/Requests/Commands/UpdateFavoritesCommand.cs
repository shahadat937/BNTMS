using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.Favorite.Requests.Commands
{
    public class UpdateFavoritesCommand : IRequest<Unit>  
    { 
        public FavoritesDto FavoritesDto { get; set; }     
    }
}
