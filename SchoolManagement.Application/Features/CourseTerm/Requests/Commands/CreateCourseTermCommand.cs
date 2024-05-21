using SchoolManagement.Application.DTOs.CourseTerm;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Commands
{
    public class CreateCourseTermCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseTermDto CourseTermDto { get; set; }

    }
}
