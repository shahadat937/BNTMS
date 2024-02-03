using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class DeleteCourseDurationCommand : IRequest
    {
        public int CourseDurationId { get; set; }
    }
}
 