using MediatR;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetCourseBudgetAllocationListRequest : IRequest<PagedResult<CourseBudgetAllocationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int? CourseNameId { get; set; } 
        public int? TraineeId { get; set; }
    }
}
