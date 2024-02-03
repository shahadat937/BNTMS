using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Queries
{
    public class GetAutoCompleteOrganizationNameRequest : IRequest<List<SelectedModel>>
    {
        public string Name { get; set; }
    }
}
 