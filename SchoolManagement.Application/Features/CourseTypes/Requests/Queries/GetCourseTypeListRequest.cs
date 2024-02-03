using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Queries
{
    public class GetCourseTypeListRequest : IRequest<PagedResult<CourseTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
