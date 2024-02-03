using MediatR;
using SchoolManagement.Application.DTOs.DefenseType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Queries
{
   public class GetDefenseTypeListRequest : IRequest<PagedResult<DefenseTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
