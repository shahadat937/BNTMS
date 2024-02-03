using MediatR;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands
{
    public class CreateFavoritesTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateFavoritesTypeDto FavoritesTypeDto { get; set; }
    }
}
