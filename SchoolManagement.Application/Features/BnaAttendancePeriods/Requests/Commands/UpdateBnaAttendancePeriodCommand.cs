using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands
{
    public class UpdateBnaAttendancePeriodCommand: IRequest<Unit>
    {
        public BnaAttendancePeriodDto BnaAttendancePeriodDto { get; set; }
    }
}
 