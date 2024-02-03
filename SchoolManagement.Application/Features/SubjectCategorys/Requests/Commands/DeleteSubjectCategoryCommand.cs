using MediatR;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands
{
    public class DeleteSubjectCategoryCommand : IRequest
    {
        public int SubjectCategoryId { get; set; }
    } 
}
