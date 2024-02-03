using SchoolManagement.Application.DTOs.BnaExamSchedule;
using MediatR;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands
{
    public class UpdateBnaExamScheduleCommand : IRequest<Unit>
    {
        public BnaExamScheduleDto BnaExamScheduleDto { get; set; }
    }
}
  