using SchoolManagement.Application.DTOs.CourseTerm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Commands
{
    public class UpdateCourseTermCommand : IRequest<Unit>
    {
        public CourseTermDto CourseTermDto { get; set; }

    }
}
