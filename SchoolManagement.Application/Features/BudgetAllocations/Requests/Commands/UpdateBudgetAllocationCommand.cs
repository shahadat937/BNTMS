using MediatR;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands
{
    public class UpdateBudgetAllocationCommand : IRequest<Unit>
    {
        public BudgetAllocationDto BudgetAllocationDto { get; set; } 
    }
}
