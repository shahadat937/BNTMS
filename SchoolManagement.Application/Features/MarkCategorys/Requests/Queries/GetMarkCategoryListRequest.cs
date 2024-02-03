using MediatR;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Queries
{
    public class GetMarkCategoryListRequest : IRequest<PagedResult<MarkCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
