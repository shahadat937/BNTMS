using MediatR;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries
{
    public class GetTdecGroupResultListRequest : IRequest<PagedResult<TdecGroupResultDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
