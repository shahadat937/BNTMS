using MediatR;
using SchoolManagement.Application.DTOs.FavoritesType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries
{
    public class GetFavoritesTypeDetailRequest : IRequest<FavoritesTypeDto>
    {
        public int FavoritesTypeId { get; set; }
    }
}
