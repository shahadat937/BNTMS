using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Queries
{
    public class GetTraineeSectionSelectionListRequest : IRequest<PagedResult<TraineeSectionSelectionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
