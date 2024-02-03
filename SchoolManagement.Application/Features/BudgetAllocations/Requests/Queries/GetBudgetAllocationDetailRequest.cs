using MediatR;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries
{
    public class GetBudgetAllocationDetailRequest : IRequest<BudgetAllocationDto>
    {
        public int BudgetAllocationId { get; set; }
    }
}
