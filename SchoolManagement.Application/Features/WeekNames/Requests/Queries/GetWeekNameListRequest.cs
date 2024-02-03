using MediatR;
using SchoolManagement.Application.DTOs.WeekName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Queries
{
   public class GetWeekNameListRequest : IRequest<PagedResult<WeekNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
