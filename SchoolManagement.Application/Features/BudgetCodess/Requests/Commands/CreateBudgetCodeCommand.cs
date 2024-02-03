using MediatR;
using SchoolManagement.Application.DTOs.BudgetCode;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Commands
{
    public class CreateBudgetCodeCommand : IRequest<BaseCommandResponse>
    {
        public CreateBudgetCodeDto BudgetCodeDto { get; set; }
    }
}
