using MediatR;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Commands
{
    public class CreateCourseTaskCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseTaskDto CourseTaskDto { get; set; }
    }
}
