using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.SubjectClassifications;

namespace SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries
{
    public class GetSubjectClassificationListRequest : IRequest<PagedResult<SubjectClassificationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
