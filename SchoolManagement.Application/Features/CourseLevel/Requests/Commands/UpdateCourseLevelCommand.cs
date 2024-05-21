using SchoolManagement.Application.DTOs.CourseLevel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Commands
{
    public class UpdateCourseLevelCommand : IRequest<Unit>
    {
        public CourseLevelDto CourseLevelDto { get; set; }

    }
}
