using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands
{
    public class UpdateAllowanceCategoryCommand : IRequest<Unit>
    {
        public AllowanceCategoryDto AllowanceCategoryDto { get; set; }
    }
}
 