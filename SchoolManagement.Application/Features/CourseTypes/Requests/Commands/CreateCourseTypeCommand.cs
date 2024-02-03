using MediatR;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Commands
{
    public class CreateCourseTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseTypeDto CourseTypeDto { get; set; }
    }
}
