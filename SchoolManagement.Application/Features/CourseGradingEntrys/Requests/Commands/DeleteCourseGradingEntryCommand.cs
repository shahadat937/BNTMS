using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands
{
    public class DeleteCourseGradingEntryCommand : IRequest
    {
        public int CourseGradingEntryId { get; set; }
    }
}
