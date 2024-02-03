using MediatR;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.Favorite.Requests.Queries
{
    public class GetFavoritesListByTraineeRequest : IRequest<List<FavoritesDto>>
    {
        public int Traineeid { get; set; }
    } 
}
