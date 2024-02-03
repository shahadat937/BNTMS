using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands
{
    public class CreateTraineeSectionSelectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeSectionSelectionDto TraineeSectionSelectionDto { get; set; }

    }
}
