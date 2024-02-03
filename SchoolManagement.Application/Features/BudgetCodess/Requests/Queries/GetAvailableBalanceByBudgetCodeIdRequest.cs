using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Queries
{
    public class GetAvailableBalanceByBudgetCodeIdRequest : IRequest<List<SelectedModel>>
    {
        public int BudgetCodeId { get; set; }
    } 
}
   