using MediatR;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands
{
    public class DeleteBnaClassScheduleCommand : IRequest
    {
        public int BnaClassScheduleId { get; set; }
    }
}
