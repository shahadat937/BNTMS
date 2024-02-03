using SchoolManagement.Application.DTOs.BnaClassSchedule;
using MediatR;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Requests.Queries
{
    public class GetBnaClassScheduleDetailRequest : IRequest<BnaClassScheduleDto>
    {
        public int BnaClassScheduleId { get; set; }
    }
}
