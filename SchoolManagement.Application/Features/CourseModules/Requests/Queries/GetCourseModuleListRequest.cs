using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Queries
{
    public class GetCourseModuleListRequest : IRequest<PagedResult<CourseModuleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
