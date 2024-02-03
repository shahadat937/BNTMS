using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries
{
    public class GetSaylorBranchListRequest : IRequest<PagedResult<SaylorBranchDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
