using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries
{
    public class GetAllowanceCategoryDetailRequest : IRequest<AllowanceCategoryDto>
    {
        public int AllowanceCategoryId { get; set; }
    }
}
 