using SchoolManagement.Application.DTOs.ParentRelative;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Queries
{
    public class GetParentRelativeListRequest : IRequest<PagedResult<ParentRelativeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
