using MediatR;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries
{
   public class GetTdecActionStatusListRequest : IRequest<PagedResult<TdecActionStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
