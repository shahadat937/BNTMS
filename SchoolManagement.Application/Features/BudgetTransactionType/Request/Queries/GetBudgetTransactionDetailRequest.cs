using MediatR;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries
{
    public class GetBudgetTransactionDetailRequest : IRequest<BudgetTransactionDto>
    {
        public int BudgetTransactionId { get;set; }
    }
}
