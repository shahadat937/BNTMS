using MediatR;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Request.Command
{
    public class UpdateBudgetTransactionCommand :IRequest<Unit>
    {
        public BudgetTransactionDto BudgetTransactionDto { get; set; }
    }
}
