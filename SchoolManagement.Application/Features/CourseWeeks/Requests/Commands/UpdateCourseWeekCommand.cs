using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Commands
{
    public class UpdateCourseWeekCommand : IRequest<Unit>
    {
        public CourseWeekAllDto CourseWeekDto { get; set; }
    }
}
