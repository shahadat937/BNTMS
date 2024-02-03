using MediatR;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands
{
    public class DeleteTraineeCourseStatusCommand : IRequest 
    {  
        public int Id { get; set; }
    }
}
