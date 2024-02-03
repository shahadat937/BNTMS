using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class DeleteCourseBudgetAllocationCommand : IRequest
    {
        public int CourseBudgetAllocationId { get; set; }
    } 
}
