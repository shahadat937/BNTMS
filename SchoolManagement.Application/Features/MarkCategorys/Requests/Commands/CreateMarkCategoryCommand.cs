using MediatR;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Commands
{
    public class CreateMarkCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateMarkCategoryDto MarkCategoryDto { get; set; } 

    }
}
