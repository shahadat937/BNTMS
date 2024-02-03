using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.KindOfSubjects.Requests.Queries  
{ 
    public class GetKindOfSubjectListRequest : IRequest<PagedResult<KindOfSubjectDto>>
    {
        public QueryParams QueryParams { get; set; } 
    }
}
