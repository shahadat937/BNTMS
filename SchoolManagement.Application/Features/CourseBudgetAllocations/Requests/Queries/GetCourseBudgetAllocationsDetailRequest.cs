using MediatR;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetCourseBudgetAllocationDetailRequest : IRequest<CourseBudgetAllocationDto>
    {
        public int CourseBudgetAllocationId { get; set; }
    }
}
