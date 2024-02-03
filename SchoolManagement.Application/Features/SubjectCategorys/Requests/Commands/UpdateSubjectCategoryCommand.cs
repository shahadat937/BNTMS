using MediatR;
using SchoolManagement.Application.DTOs.SubjectCategorys;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands
{
    public class UpdateSubjectCategoryCommand : IRequest<Unit>
    { 
        public SubjectCategoryDto SubjectCategoryDto { get; set; }
    }
}
