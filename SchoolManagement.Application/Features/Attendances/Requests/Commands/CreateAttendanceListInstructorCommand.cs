using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Commands
{
    public class CreateAttendanceListInstructorCommand : IRequest<BaseCommandResponse>
    { 
        public CreateAttendanceListDtoInstructor AttendanceListInstructorDto { get; set; }
    }
} 
 