using MediatR;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Commands
{
    public class DeleteMarkCategoryCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
