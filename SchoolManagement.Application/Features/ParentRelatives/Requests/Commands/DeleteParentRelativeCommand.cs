using MediatR;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Commands
{
    public class DeleteParentRelativeCommand : IRequest
    {
        public int ParentRelativeId { get; set; }
    }
}
