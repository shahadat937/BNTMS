using MediatR;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries
{
    public class GetAllowancePercentageListRequest : IRequest<PagedResult<AllowancePercentageDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 