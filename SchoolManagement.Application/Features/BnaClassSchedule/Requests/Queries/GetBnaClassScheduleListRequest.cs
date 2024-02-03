using SchoolManagement.Application.DTOs.BnaClassSchedule;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Requests.Queries
{
    public class GetBnaClassScheduleListRequest : IRequest<PagedResult<BnaClassScheduleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
