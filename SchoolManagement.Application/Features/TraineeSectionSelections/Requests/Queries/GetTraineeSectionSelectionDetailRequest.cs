using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using MediatR;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Queries
{
    public class GetTraineeSectionSelectionDetailRequest : IRequest<TraineeSectionSelectionDto>
    {
        public int TraineeSectionSelectionId { get; set; }
    }
}
