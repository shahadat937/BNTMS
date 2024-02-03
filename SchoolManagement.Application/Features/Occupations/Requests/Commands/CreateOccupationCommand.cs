using MediatR;
using SchoolManagement.Application.DTOs.Occupation;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Occupations.Requests.Commands
{
    public class CreateOccupationCommand : IRequest<BaseCommandResponse>
    {
        public CreateOccupationDto OccupationDto { get; set; }
    }
}
