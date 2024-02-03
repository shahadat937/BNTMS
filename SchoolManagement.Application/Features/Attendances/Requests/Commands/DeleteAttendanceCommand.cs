using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class DeleteAttendanceCommand : IRequest
    {
        public int AttendanceId { get; set; }
    }
}
