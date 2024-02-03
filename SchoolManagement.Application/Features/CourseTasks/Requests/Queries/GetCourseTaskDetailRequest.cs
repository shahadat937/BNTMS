using MediatR;
using SchoolManagement.Application.DTOs.CourseTask;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Queries
{
    public class GetCourseTaskDetailRequest : IRequest<CourseTaskDto>
    {
        public int CourseTaskId { get; set; }
    }
}
