using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands
{
    public class CreateBnaAttendanceRemarkCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaAttendanceRemarkDto BnaAttendanceRemarkDto { get; set; } 
    }
}
 