using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSubjectMarkListRequest : IRequest<PagedResult<SubjectMarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
