using SchoolManagement.Application.DTOs.GrandFatherType;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries
{
    public class GetGrandFatherTypeListRequest : IRequest<PagedResult<GrandFatherTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
