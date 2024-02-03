using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries
{
    public class GetBnaAttendanceRemarkListRequest : IRequest<PagedResult<BnaAttendanceRemarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
