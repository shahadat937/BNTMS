using MediatR;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Application.Responses;


namespace SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands
{
    public class CreateCourseWeekAllCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseWeekAllDto CourseWeekAllDto { get; set; }
    }
}
