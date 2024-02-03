using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Commands
{
    public class CreateCourseInstructorCommand : IRequest<BaseCommandResponse>
    {
        public ModifiedCreateCourseInstructorDto CourseInstructorDto { get; set; }
    }
}
 