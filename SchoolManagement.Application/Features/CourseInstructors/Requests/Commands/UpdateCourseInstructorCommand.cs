using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Commands
{
    public class UpdateCourseInstructorCommand : IRequest<Unit>
    {
        public CourseInstructorDto CourseInstructorDto { get; set; }
    }
}
 