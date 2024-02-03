using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries
{
    public class GetBnaAttendancePeriodListRequest : IRequest<PagedResult<BnaAttendancePeriodDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
