using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BaseNames.Requests.Queries
{
    public class GetSelectedBaseNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
