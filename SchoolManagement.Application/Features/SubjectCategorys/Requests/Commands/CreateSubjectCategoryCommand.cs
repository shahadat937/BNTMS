using MediatR;
using SchoolManagement.Application.DTOs.SubjectCategorys;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands
{
    public class CreateSubjectCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateSubjectCategoryDto SubjectCategoryDto { get; set; }
    }
}
