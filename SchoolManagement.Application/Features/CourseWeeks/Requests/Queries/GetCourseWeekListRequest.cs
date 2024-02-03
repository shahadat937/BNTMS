using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetCourseWeekListRequest : IRequest<PagedResult<CourseWeekDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
