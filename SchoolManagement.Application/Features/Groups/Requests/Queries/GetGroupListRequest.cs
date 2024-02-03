using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Groups;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Groups.Requests.Queries
{
    public class GetGroupListRequest : IRequest<PagedResult<GroupDto>>
    {
        public QueryParams QueryParams { get; set; }  
    }
}
