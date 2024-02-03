using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Queries
{
    public class GetMembershipTypeListRequest : IRequest<PagedResult<MembershipTypeDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
