using SchoolManagement.Application.DTOs.BnaExamSchedule;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries
{
    public class GetBnaExamScheduleListRequest : IRequest<PagedResult<BnaExamScheduleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
  