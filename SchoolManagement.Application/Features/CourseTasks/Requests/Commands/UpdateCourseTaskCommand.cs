using MediatR;
using SchoolManagement.Application.DTOs.CourseTask;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Commands
{
    public class UpdateCourseTaskCommand : IRequest<Unit>
    {
        public CourseTaskDto CourseTaskDto { get; set; }
    }
}
