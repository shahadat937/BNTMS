using SchoolManagement.Application.DTOs.Attendance;
using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class UpdateAttendanceCommand : IRequest<Unit>
    {
        public AttendanceDto AttendanceDto { get; set; }

    }
}
