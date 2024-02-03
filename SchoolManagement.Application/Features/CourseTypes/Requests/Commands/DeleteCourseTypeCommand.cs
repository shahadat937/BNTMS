using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Commands
{
    public class DeleteCourseTypeCommand : IRequest
    {
        public int CourseTypeId { get; set; }
    }
}
