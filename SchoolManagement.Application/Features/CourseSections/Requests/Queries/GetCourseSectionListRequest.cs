using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseSection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Queries
{
    public class GetCourseSectionListRequest : IRequest<PagedResult<CourseSectionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
