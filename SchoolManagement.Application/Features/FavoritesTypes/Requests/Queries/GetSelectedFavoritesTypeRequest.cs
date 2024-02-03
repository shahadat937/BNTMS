using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries
{
    public class GetSelectedFavoritesTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
 