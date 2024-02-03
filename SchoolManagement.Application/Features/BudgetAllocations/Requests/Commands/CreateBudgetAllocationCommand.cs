using MediatR;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands
{
    public class CreateBudgetAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateBudgetAllocationDto BudgetAllocationDto { get; set; } 

    }
}
