using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.Favorite.Requests.Queries
{
    public class GetFavoritesDetailRequest : IRequest<FavoritesDto> 
    {
        public int Id { get; set; } 
    }
}
