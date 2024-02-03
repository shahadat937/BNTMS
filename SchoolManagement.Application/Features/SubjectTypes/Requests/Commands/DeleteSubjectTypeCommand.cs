using MediatR;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Commands
{
    public class DeleteSubjectTypeCommand : IRequest
    {
        public int SubjectTypeId { get; set; } 
    }
}
