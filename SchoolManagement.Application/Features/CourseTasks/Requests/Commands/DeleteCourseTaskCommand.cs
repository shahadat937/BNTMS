using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Commands
{
    public class DeleteCourseTaskCommand : IRequest
    {
        public int CourseTaskId { get; set; }
    }
}
