using MediatR;
using SchoolManagement.Application.DTOs.Occupation;

namespace SchoolManagement.Application.Features.Occupations.Requests.Queries
{
    public class GetOccupationDetailRequest : IRequest<OccupationDto>
    {
        public int OccupationId { get; set; }
    }
}
