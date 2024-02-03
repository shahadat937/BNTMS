using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SubjectCategorys;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries
{
   public class GetSubjectCategoryListRequest : IRequest<PagedResult<SubjectCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
