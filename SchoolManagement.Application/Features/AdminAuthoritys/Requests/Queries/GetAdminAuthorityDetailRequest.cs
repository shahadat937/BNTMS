using MediatR;
using SchoolManagement.Application.DTOs.AdminAuthority;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries
{
    public class GetAdminAuthorityDetailRequest : IRequest<AdminAuthorityDto>
    {
        public int AdminAuthorityId { get; set; }
    }
}
