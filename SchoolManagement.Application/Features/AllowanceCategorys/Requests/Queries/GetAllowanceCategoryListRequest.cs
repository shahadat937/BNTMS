using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries
{
    public class GetAllowanceCategoryListRequest : IRequest<PagedResult<AllowanceCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 