using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands
{
    public class CreateBnaAttendancePeriodCommand: IRequest<BaseCommandResponse>
    {
        public CreateBnaAttendancePeriodDto BnaAttendancePeriodDto { get; set; }
    }
}
