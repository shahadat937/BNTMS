using MediatR;
using SchoolManagement.Application.DTOs.BudgetType;

namespace SchoolManagement.Application.Features.BudgetTypes.Requests.Commands
{
    public class UpdateBudgetTypeCommand : IRequest<Unit>
    {
        public BudgetTypeDto BudgetTypeDto { get; set; }
    }
}
