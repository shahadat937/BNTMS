using MediatR;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries
{
    public class GetAdminAuthorityListRequest : IRequest<PagedResult<AdminAuthorityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
