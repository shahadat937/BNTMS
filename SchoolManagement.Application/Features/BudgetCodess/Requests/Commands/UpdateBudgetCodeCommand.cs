using MediatR;
using SchoolManagement.Application.DTOs.BudgetCode;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Commands
{
    public class UpdateBudgetCodeCommand : IRequest<Unit>
    {
        public BudgetCodeDto BudgetCodeDto { get; set; }
    }
}
