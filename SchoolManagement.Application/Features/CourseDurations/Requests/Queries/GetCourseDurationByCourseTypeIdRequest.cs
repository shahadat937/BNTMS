using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationByCourseTypeIdRequest : IRequest<PagedResult<CourseDurationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int CourseTypeId { get; set; }
    }
}
 