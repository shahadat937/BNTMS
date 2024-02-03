using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Commands
{
    public class CreateCourseSectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseSectionDto CourseSectionDto { get; set; }

    }
}
