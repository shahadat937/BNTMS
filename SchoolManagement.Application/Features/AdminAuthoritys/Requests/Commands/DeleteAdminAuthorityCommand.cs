using MediatR;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands
{
    public class DeleteAdminAuthorityCommand : IRequest
    {
        public int AdminAuthorityId { get; set; }
    }
}
