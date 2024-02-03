using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries
{
    public class GetSelectedAdminAuthorityRequest : IRequest<List<SelectedModel>>
    {
    }
}
