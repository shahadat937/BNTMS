using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Queries
{
    public class GetCourseModuleDetailRequest : IRequest<CourseModuleDto>
    {
        public int CourseModuleId { get; set; }
    }
}
