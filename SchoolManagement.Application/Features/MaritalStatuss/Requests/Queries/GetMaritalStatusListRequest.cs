using MediatR;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries
{
    public class GetMaritalStatusListRequest : IRequest<PagedResult<MaritalStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
