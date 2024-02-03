using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BaseNames.Requests.Queries 
{ 
    public class GetBaseNameListRequest : IRequest<PagedResult<BaseNameDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
