using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetCourseWeekDetailRequest : IRequest<CourseWeekDto>
    {
        public int CourseWeekId { get; set; }
    }
}
