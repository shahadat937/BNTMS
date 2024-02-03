using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ResultStatus;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Queries
{
   public class GetResultStatusListRequest : IRequest<PagedResult<ResultStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
