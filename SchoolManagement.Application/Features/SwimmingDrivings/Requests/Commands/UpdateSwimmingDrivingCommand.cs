using SchoolManagement.Application.DTOs.SwimmingDriving;
using MediatR;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands
{
    public class UpdateSwimmingDrivingCommand : IRequest<Unit>
    {
        public SwimmingDrivingDto SwimmingDrivingDto { get; set; }

    }
}
