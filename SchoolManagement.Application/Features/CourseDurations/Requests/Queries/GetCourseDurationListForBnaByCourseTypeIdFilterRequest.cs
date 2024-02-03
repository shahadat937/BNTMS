using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationListForBnaByCourseTypeIdFilterRequest : IRequest<object>
    {
        public int CourseTypeId { get; set; }
        public int ViewStatus { get; set; }
    }
}
  