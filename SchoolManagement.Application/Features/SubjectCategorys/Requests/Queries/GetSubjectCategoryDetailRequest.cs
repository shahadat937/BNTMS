using MediatR;
using SchoolManagement.Application.DTOs.SubjectCategorys;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries
{
    public class GetSubjectCategoryDetailRequest : IRequest<SubjectCategoryDto>
    {
        public int SubjectCategoryId { get; set; }
    }
}
