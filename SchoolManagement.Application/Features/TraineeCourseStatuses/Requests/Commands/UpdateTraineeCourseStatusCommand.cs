using MediatR;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands
{
    public class UpdateTraineeCourseStatusCommand : IRequest<Unit>  
    { 
        public TraineeCourseStatusDto TraineeCourseStatusDto { get; set; }     
    }
}
