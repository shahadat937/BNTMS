using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Commands
{
    public class DeleteCourseTermCommand : IRequest
    {
        public int CourseTermId { get; set; }
    }
}
