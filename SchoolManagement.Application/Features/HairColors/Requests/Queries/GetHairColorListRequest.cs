using MediatR;
using SchoolManagement.Application.DTOs.HairColor;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Queries
{
   public class GetHairColorListRequest : IRequest<PagedResult<HairColorDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
