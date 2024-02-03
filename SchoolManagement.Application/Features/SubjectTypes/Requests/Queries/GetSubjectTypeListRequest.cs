using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SubjectTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Queries
{
   public class GetSubjectTypeListRequest : IRequest<PagedResult<SubjectTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
