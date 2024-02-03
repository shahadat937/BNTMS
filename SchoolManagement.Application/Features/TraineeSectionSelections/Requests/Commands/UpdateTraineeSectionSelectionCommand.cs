using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using MediatR;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands
{
    public class UpdateTraineeSectionSelectionCommand : IRequest<Unit>
    {
        public TraineeSectionSelectionDto TraineeSectionSelectionDto { get; set; }

    }
}
