using MediatR;
using SchoolManagement.Application.DTOs.BudgetType;

namespace SchoolManagement.Application.Features.BudgetTypes.Requests.Queries
{
    public class GetBudgetTypeDetailRequest : IRequest<BudgetTypeDto>
    {
        public int BudgetTypeId { get; set; }
    }
}
