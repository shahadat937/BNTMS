using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries
{
   public class GetCourseGradingEntryListRequest : IRequest<PagedResult<CourseGradingEntryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
