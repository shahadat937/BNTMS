using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries
{
    public class GetFinancialSanctionListRequest : IRequest<PagedResult<FinancialSanctionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
