using MediatR;
using SchoolManagement.Application.DTOs.Occupation;

namespace SchoolManagement.Application.Features.Occupations.Requests.Commands
{
    public class UpdateOccupationCommand : IRequest<Unit>
    {
        public OccupationDto OccupationDto { get; set; }
    }
}
