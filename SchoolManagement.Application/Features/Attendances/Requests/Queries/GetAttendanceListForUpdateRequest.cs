using SchoolManagement.Application.DTOs.Attendance;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetAttendanceListForUpdateRequest : IRequest<PagedResult<AttendanceDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get;set;}
        public int CourseNameId { get; set; } 
        public int ClassPeriodId { get; set; }
    } 
}
