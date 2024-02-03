using MediatR;
using SchoolManagement.Application.DTOs.OrganizationName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.OrganizationNames.Requests.Commands
{
    public class CreateOrganizationNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrganizationNameDto OrganizationNameDto { get; set; }
    }
}
