using SchoolManagement.Application.DTOs.BnaClassSchedule;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands
{
    public class CreateBnaClassScheduleCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaClassScheduleDto BnaClassScheduleDto { get; set; }

    }
}
