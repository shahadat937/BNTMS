using MediatR;
using SchoolManagement.Application.DTOs.ForceType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Queries
{
   public class GetForceTypeListRequest : IRequest<PagedResult<ForceTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
