using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands
{
    public class DeleteBudgetAllocationCommand : IRequest
    {
        public int BudgetAllocationId { get; set; }
    } 
}
