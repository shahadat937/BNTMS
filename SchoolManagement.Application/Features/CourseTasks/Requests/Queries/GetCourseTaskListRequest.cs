using MediatR;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Queries
{
   public class GetCourseTaskListRequest : IRequest<PagedResult<CourseTaskDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
