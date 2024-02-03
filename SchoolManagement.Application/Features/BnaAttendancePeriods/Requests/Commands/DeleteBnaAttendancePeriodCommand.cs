using MediatR;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands
{
    public class DeleteBnaAttendancePeriodCommand: IRequest
    {
        public int BnaAttendancePeriodId { get; set; }
    }
}
 