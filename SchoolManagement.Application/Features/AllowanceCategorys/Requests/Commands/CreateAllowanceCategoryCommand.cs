using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands
{
    public class CreateAllowanceCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateAllowanceCategoryDto AllowanceCategoryDto { get; set; }
    }
}
 