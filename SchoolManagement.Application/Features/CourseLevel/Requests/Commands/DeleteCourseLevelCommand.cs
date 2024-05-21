using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Commands
{
    public class DeleteCourseLevelCommand : IRequest
    {
        public int CourseLevelId { get; set; }
    }
}
