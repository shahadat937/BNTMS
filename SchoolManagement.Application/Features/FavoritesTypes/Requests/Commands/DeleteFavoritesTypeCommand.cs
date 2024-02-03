using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands
{
    public class DeleteFavoritesTypeCommand : IRequest
    {
        public int FavoritesTypeId { get; set; }
    }
}
