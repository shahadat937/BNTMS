using MediatR;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetCourseBudgetAllocationsListByPaymentTypeIdAndCourseDurationIdRequest : IRequest<PagedResult<CourseBudgetAllocationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int? CourseDurationId { get; set; }   
        public int? PaymentTypeId { get; set; }
    }
}
 