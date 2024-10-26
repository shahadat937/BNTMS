using MediatR;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Request.Command
{
    public class CreateBudgetTransactionCommandHandler : IRequest<BaseCommandResponse>
    {
        public CreateBudgetTransactionDto BudgetTransactionDto { get; set; }
    }
}
