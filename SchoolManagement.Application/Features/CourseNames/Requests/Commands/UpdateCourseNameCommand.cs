using SchoolManagement.Application.DTOs.CourseName;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Commands
{
    public class UpdateCourseNameCommand : IRequest<Unit>
    {
        public CreateCourseNameDto CreateCourseNameDto { get; set; }

    }
}
