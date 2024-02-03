using MediatR;
using SchoolManagement.Application.DTOs.CourseNomenees;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{
    public class UpdateCourseNomeneeCommand : IRequest<Unit>
    {
        public CourseNomeneeDto CourseNomeneeDto { get; set; }
    }
}
 