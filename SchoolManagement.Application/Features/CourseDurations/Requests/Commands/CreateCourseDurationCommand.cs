using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class CreateCourseDurationCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDurationDto CourseDurationDto { get; set; }
    }
}
