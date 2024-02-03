using MediatR;
using SchoolManagement.Application.DTOs.OrganizationName;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Queries
{
    public class GetOrganizationNameDetailRequest : IRequest<OrganizationNameDto>
    {
        public int OrganizationNameId { get; set; }
    }
}
