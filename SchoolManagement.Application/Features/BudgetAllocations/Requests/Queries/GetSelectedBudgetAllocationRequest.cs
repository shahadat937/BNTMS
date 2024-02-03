using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries
{
    public class GetSelectedBudgetAllocationRequest : IRequest<List<SelectedModel>>
    {
    }
}
     