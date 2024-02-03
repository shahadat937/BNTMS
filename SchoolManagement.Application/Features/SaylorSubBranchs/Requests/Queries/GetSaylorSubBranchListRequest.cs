using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries
{
    public class GetSaylorSubBranchListRequest : IRequest<PagedResult<SaylorSubBranchDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
