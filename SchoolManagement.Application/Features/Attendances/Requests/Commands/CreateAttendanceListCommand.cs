using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class CreateAttendanceListCommand : IRequest<BaseCommandResponse>
    {
         public List<CreateAttendanceListDto> AttendanceListDto { get; set; }
    }
} 
 