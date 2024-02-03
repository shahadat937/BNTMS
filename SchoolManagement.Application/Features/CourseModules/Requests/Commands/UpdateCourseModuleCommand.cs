using SchoolManagement.Application.DTOs.CourseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Commands
{
    public class UpdateCourseModuleCommand : IRequest<Unit>
    {
        public CourseModuleDto CourseModuleDto { get; set; }

    }
}
