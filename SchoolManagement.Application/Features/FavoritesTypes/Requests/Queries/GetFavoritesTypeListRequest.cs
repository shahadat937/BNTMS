using MediatR;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries
{
   public class GetFavoritesTypeListRequest : IRequest<PagedResult<FavoritesTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
