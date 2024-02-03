using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries
{
   public class GetForeignCourseGOInfoListRequest : IRequest<PagedResult<ForeignCourseGOInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
