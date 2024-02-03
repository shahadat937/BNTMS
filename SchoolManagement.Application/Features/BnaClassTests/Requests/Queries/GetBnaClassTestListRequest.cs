using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaClassTests.Requests.Queries
{
    public class GetBnaClassTestListRequest: IRequest<PagedResult<BnaClassTestDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
