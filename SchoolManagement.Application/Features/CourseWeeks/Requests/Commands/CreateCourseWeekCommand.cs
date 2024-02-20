using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Commands
{
    public class CreateCourseWeekCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseWeekDto CourseWeekDto { get; set; }
    }
}
