using MediatR;
using SchoolManagement.Application.DTOs.CourseTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Commands
{
    public class UpdateCourseTypeCommand : IRequest<Unit>
    {
        public CourseTypeDto CourseTypeDto { get; set; }
    }
}
