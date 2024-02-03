using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{
    public class DeleteCourseNomeneeCommand : IRequest
    {
        public int CourseNomeneeId { get; set; }
    }
}
 