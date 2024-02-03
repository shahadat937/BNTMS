using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Commands
{
    public class DeleteBudgetCodeCommand : IRequest
    {
        public int BudgetCodeId { get; set; }
    }
}
 