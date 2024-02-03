using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Queries
{ 
   public class GetCourseNomeneeListRequest : IRequest<PagedResult<CourseNomeneeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
