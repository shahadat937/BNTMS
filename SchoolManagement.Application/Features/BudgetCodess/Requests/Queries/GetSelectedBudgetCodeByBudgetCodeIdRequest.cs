using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Queries
{
    public class GetSelectedBudgetCodeByBudgetCodeIdRequest : IRequest<List<SelectedModel>>
    {
        public int BudgetCodeId { get; set; }
    }
}
  