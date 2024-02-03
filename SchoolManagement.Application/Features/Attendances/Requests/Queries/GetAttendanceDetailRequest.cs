using SchoolManagement.Application.DTOs.Attendance;
using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetAttendanceDetailRequest : IRequest<AttendanceDto>
    {
        public int AttendanceId { get; set; }
    }
}
