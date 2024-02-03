using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{ 
   public class GetCourseInstructorListRequest : IRequest<PagedResult<CourseInstructorDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
