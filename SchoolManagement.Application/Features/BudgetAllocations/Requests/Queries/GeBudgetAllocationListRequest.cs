using MediatR;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries
{
    public class GetBudgetAllocationListRequest : IRequest<PagedResult<BudgetAllocationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int? BudgetCodeId { get; set; }  
        public int? FiscalYearId { get; set; } 
    }
}
