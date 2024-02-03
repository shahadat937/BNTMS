using MediatR;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries
{
   public class GetTdecQuationGroupListRequest : IRequest<PagedResult<TdecQuationGroupDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
