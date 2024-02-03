using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries
{
   public class GetForeignCourseDocTypeListRequest : IRequest<PagedResult<ForeignCourseDocTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
