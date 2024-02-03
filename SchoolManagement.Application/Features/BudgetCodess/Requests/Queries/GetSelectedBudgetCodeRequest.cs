using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Queries
{
    public class GetSelectedBudgetCodeRequest : IRequest<List<SelectedModel>>
    {
    }
}
 