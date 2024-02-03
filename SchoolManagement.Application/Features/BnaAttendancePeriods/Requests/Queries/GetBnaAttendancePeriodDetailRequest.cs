using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries
{
    public class GetBnaAttendancePeriodDetailRequest : IRequest<BnaAttendancePeriodDto>
    {
        public int BnaAttendancePeriodId { get; set; }
    }
}
 