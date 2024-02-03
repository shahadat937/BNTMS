using MediatR;
using SchoolManagement.Application.DTOs.MarkCategory;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Queries
{
    public class GetMarkCategoryDetailRequest : IRequest<MarkCategoryDto>
    {
        public int Id { get; set; }
    }
}
