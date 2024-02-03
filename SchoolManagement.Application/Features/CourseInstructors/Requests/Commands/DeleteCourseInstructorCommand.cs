using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Commands
{
    public class DeleteCourseInstructorCommand : IRequest
    {
        public int CourseInstructorId { get; set; }
    }
}
 