using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MembershipTypes.Requests.Queries
{
    public class GetSelectedMembershipTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
