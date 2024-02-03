using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BudgetTypes.Requests.Queries
{
    public class GetBudgetTypeListRequest : IRequest<PagedResult<BudgetTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
