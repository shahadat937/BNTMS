using MediatR;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Commands
{
    public class DeleteOrganizationNameCommand : IRequest
    {
        public int OrganizationNameId { get; set; }
    }
}
