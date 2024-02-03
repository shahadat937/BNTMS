using MediatR;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands
{
    public class DeleteAllowanceCategoryCommand : IRequest
    {
        public int AllowanceCategoryId { get; set; }
    }
}
 