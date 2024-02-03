using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Queries
{
    public class GetSelectedOrganizationNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
