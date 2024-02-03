using MediatR;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands
{
    public class DeleteBnaAttendanceRemarkCommand : IRequest
    {
        public int BnaAttendanceRemarksId { get; set; } 
    }
}
 