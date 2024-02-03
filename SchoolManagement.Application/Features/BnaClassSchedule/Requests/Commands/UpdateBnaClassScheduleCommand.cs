using SchoolManagement.Application.DTOs.BnaClassSchedule;
using MediatR;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands
{
    public class UpdateBnaClassScheduleCommand : IRequest<Unit>
    {
        public BnaClassScheduleDto BnaClassScheduleDto { get; set; }

    }
}
