﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands
{
    public class DeleteBudgetAllocationCommandHandler : IRequest
    {
        public int BudgetAllocationId { get; set; }
    } 
}
