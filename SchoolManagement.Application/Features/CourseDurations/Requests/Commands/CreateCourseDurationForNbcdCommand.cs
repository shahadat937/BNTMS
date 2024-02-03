using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class CreateCourseDurationForNbcdCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDurationDto CourseDurationDto { get; set; }
        public int BaseSchoolNameId { get; set;}
    }
}
 