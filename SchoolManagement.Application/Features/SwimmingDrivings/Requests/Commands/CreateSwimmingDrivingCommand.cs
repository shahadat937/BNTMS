using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands
{
    public class CreateSwimmingDrivingCommand : IRequest<BaseCommandResponse>
    {
        public CreateSwimmingDrivingDto SwimmingDrivingDto { get; set; }

    }
}
