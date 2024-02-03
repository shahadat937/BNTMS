using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries 
{ 
    public class GetBnaSubjectNameListRequest : IRequest<PagedResult<BnaSubjectNameDto>>
    { 
        public QueryParams QueryParams { get; set; }
        public int Status { get; set; }
    }
} 
 