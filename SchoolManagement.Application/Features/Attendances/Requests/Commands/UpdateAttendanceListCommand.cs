using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class UpdateAttendanceListCommand : IRequest<BaseCommandResponse>
    {
      public ApprovedAttendanceDto ApprovedAttendanceDto { get; set; }
    }
} 
 