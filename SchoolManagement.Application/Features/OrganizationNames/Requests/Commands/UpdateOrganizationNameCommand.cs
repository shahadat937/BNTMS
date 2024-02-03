using MediatR;
using SchoolManagement.Application.DTOs.OrganizationName;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Commands
{
    public class UpdateOrganizationNameCommand : IRequest<Unit>
    {
        public OrganizationNameDto OrganizationNameDto { get; set; }
    }
}
