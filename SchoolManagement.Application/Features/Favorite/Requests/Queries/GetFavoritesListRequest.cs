using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Favorite.Requests.Queries
{
    public class GetFavoritesListRequest : IRequest<PagedResult<FavoritesDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
