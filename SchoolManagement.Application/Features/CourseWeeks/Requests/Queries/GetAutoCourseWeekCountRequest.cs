using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetAutoCourseWeekCountRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
