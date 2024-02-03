using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Commands
{
    public class CreateParentRelativeCommand : IRequest<BaseCommandResponse>
    {
        public CreateParentRelativeDto ParentRelativeDto { get; set; }

    }
}
