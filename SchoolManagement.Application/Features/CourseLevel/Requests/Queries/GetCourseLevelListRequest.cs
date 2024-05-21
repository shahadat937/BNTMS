using SchoolManagement.Application.DTOs.CourseLevel;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Queries
{
    public class GetCourseLevelListRequest : IRequest<PagedResult<CourseLevelDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
