using MediatR;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands
{
    public class CreateTraineeCourseStatusesCommand : IRequest<BaseCommandResponse> 
    {
        public CreateTraineeCourseStatusDto TraineeCourseStatusDto { get; set; }      

    }
}
