using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Queries
{
    public class GetInstallmentPaidDetailListRequest : IRequest<PagedResult<InstallmentPaidDetailDto>>
    {
        public QueryParams QueryParams { get; set; } 
    }
}
