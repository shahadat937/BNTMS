using MediatR;

namespace SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands
{
    public class DeleteKindOfSubjectCommand : IRequest
    {  
        public int Id { get; set; }
    } 
}
