using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class CreateAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateAttendanceDto AttendanceDto { get; set; }
    }
}
