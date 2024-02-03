using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Queries
{
    public class GetBranchListRequest : IRequest<PagedResult<BranchDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
