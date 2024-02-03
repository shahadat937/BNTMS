using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries
{
   public class GetForeignCourseOtherDocListRequest : IRequest<PagedResult<ForeignCourseOtherDocDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
