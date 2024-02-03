using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Queries
{
    public class GetJoiningReasonListRequest : IRequest<PagedResult<JoiningReasonDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
