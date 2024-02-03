using MediatR;

namespace SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands
{
    public class DeleteSubjectClassificationCommand : IRequest
    {
        public int SubjectClassificationId { get; set; } 
    }
}
