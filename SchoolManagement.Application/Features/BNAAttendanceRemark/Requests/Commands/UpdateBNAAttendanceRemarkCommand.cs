using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands
{
    public class UpdateBnaAttendanceRemarkCommand : IRequest<Unit>
    {
        public BnaAttendanceRemarkDto BnaAttendanceRemarkDto { get; set; }
    }
}
  