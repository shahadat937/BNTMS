using MediatR;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class UpdateCourseBudgetAllocationCommand : IRequest<Unit>
    {
        public CourseBudgetAllocationDto CourseBudgetAllocationDto { get; set; } 
    }
}
