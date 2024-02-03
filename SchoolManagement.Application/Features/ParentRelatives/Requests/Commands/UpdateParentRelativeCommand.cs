using MediatR;
using SchoolManagement.Application.DTOs.ParentRelative;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Commands
{
    public class UpdateParentRelativeCommand : IRequest<Unit>
    {
        public ParentRelativeDto ParentRelativeDto { get; set; } 

    }
}
