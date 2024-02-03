using MediatR;
using SchoolManagement.Application.DTOs.ReasonType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypes.Requests.Queries
{
   public class GetReasonTypeListRequest : IRequest<PagedResult<ReasonTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
