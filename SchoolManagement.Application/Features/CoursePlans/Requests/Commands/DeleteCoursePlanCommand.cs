using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Commands
{
    public class DeleteCoursePlanCommand : IRequest
    {
        public int CoursePlanCreateId { get; set; } 
    }
}
