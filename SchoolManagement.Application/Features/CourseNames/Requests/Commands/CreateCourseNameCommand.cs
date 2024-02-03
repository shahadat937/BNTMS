using SchoolManagement.Application.DTOs.CourseName;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Commands
{
    public class CreateCourseNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseNameDto CourseNameDto { get; set; }

    }
} 
