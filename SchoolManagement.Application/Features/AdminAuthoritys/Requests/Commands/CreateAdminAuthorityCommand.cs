using MediatR;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands
{
    public class CreateAdminAuthorityCommand : IRequest<BaseCommandResponse>
    {
        public CreateAdminAuthorityDto AdminAuthorityDto { get; set; }
    }
}
