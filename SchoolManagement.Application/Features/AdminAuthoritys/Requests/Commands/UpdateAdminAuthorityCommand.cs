using MediatR;
using SchoolManagement.Application.DTOs.AdminAuthority;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands
{
    public class UpdateAdminAuthorityCommand : IRequest<Unit>
    {
        public AdminAuthorityDto AdminAuthorityDto { get; set; }
    }
}
