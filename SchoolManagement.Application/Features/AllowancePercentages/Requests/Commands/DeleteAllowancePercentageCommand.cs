using MediatR;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands
{
    public class DeleteAllowancePercentageCommand : IRequest
    {
        public int AllowancePercentageId { get; set; }
    }
}
 