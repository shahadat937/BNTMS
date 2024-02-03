using MediatR;
using SchoolManagement.Application.DTOs.Occupation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Occupations.Requests.Queries
{
    public class GetOccupationListRequest : IRequest<PagedResult<OccupationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
