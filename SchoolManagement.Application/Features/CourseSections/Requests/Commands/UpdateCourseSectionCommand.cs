using SchoolManagement.Application.DTOs.CourseSection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Commands
{
    public class UpdateCourseSectionCommand : IRequest<Unit>
    {
        public CourseSectionDto CourseSectionDto { get; set; }

    }
}
