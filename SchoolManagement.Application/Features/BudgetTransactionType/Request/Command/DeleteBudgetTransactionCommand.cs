using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Request.Command
{
    public class DeleteBudgetTransactionCommand :IRequest
    {
       public int BudgetTransactionId { get; set; }
    }
}
