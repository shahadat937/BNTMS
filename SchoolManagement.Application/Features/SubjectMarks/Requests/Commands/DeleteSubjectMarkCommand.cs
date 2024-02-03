using MediatR;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Commands
{
    public class DeleteSubjectMarkCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
