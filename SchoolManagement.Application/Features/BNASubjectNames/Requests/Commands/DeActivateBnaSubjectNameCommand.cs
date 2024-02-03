using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class DeActivateBnaSubjectNameCommand : IRequest 
    {
        public int BnaSubjectNameId { get; set; } 
    }
}
  