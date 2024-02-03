using MediatR;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetTypes.Requests.Commands
{
    public class CreateBudgetTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateBudgetTypeDto BudgetTypeDto { get; set; }
    }
}
