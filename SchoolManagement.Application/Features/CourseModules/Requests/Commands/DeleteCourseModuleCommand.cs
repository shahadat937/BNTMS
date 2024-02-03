using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Commands
{
    public class DeleteCourseModuleCommand : IRequest
    {
        public int CourseModuleId { get; set; }
    }
}
