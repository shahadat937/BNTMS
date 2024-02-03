using MediatR;
using SchoolManagement.Application.DTOs.MarkCategory;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Commands
{
    public class UpdateMarkCategoryCommand : IRequest<Unit>
    {
        public MarkCategoryDto MarkCategoryDto { get; set; } 
    }
}
