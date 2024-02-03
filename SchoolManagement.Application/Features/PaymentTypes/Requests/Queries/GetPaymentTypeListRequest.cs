using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Queries
{
    public class GetPaymentTypeListRequest : IRequest<PagedResult<PaymentTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
