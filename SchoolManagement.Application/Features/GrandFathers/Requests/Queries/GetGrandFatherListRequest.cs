using SchoolManagement.Application.DTOs.GrandFather;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Queries
{
    public class GetGrandFatherListRequest : IRequest<PagedResult<GrandFatherDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
