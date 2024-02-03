using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries
{
    public class GetBnaAttendanceRemarkDetailRequest : IRequest<BnaAttendanceRemarkDto>
    {
        public int BnaAttendanceRemarksId { get; set; }
    }
} 
 