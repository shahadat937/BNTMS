using MediatR;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Queries
{
    public class GetMarkTypeListRequest : IRequest<PagedResult<MarkTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
