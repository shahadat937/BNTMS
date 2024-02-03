using MediatR;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands
{
    public class DeleteTraineeSectionSelectionCommand : IRequest
    {
        public int TraineeSectionSelectionId { get; set; }
    }
}
