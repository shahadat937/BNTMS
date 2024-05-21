using SchoolManagement.Application.DTOs.CourseTerm;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Queries
{
    public class GetCourseTermListRequest : IRequest<PagedResult<CourseTermDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
