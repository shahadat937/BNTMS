using MediatR;
using SchoolManagement.Application.DTOs.FavoritesType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands
{
    public class UpdateFavoritesTypeCommand : IRequest<Unit>
    {
        public FavoritesTypeDto FavoritesTypeDto { get; set; }
    }
}
