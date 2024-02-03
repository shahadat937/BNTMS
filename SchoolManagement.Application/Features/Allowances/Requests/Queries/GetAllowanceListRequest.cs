using MediatR;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Allowances.Requests.Queries
{
   public class GetAllowanceListRequest : IRequest<PagedResult<AllowanceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 