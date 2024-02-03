using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseName;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetCourseNameListRequest : IRequest<PagedResult<CourseNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
