using MediatR;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands
{
    public class DeleteSwimmingDrivingCommand : IRequest
    {
        public int SwimmingDrivingId { get; set; }
    }
}
