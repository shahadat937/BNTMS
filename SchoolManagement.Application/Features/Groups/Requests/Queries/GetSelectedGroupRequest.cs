using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Groups.Requests.Queries
{
    public class GetSelectedGroupRequest : IRequest<List<SelectedModel>>
    {
    }
}
