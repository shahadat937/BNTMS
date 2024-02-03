using MediatR;
using SchoolManagement.Application.DTOs.OrganizationName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Queries
{
    public class GetOrganizationNameListRequest : IRequest<PagedResult<OrganizationNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
