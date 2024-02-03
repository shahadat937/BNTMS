using SchoolManagement.Application.DTOs.BnaExamSchedule;
using MediatR;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries
{
    public class GetBnaExamScheduleDetailRequest : IRequest<BnaExamScheduleDto>
    {
        public int BnaExamScheduleId { get; set; }
    }
}
  