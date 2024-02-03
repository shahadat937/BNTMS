using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class ActivateBnaSubjectNameCommand : IRequest 
    {
        public int BnaSubjectNameId { get; set; } 
    }
}
   