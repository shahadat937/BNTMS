using MediatR;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{
    public class CreateCourseNomeneeCommand : IRequest<BaseCommandResponse>
    {
        public ModifiedCreateCourseNomeneeDto CourseNomeneeDto { get; set; }
    }
}
 