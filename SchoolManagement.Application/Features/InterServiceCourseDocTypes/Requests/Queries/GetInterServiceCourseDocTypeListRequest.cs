using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries
{
   public class GetInterServiceCourseDocTypeListRequest : IRequest<PagedResult<InterServiceCourseDocTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
