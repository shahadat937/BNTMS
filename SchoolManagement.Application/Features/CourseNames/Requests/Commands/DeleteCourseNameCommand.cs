using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Commands
{
    public class DeleteCourseNameCommand : IRequest
    {
        public int CourseNameId { get; set; }
    }
}
