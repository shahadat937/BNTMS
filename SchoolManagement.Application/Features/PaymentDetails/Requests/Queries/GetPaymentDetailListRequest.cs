using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Queries
{
    public class GetPaymentDetailListRequest : IRequest<PagedResult<PaymentDetailDto>>
    {
        public QueryParams QueryParams { get; set; } 
    }
}
