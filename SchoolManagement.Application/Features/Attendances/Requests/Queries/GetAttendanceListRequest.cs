using SchoolManagement.Application.DTOs.Attendance;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetAttendanceListRequest : IRequest<PagedResult<AttendanceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
