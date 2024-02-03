using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries
{
   public class GetBnaClassScheduleStatusListRequest : IRequest<PagedResult<BnaClassScheduleStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
   