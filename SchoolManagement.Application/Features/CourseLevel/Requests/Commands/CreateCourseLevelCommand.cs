using SchoolManagement.Application.DTOs.CourseLevel;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Commands
{
    public class CreateCourseLevelCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseLevelDto CourseLevelDto { get; set; }

    }
}
