using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetTypes.Requests.Commands
{
    public class DeleteBudgetTypeCommand : IRequest
    {
        public int BudgetTypeId { get; set; }
    }
}
 