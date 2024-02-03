using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Commands
{
    public class DeleteCourseSectionCommand : IRequest
    {
        public int CourseSectionId { get; set; }
    }
}
