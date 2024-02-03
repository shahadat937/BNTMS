using MediatR;
using SchoolManagement.Application.DTOs.PaymentDetail;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Queries
{
    public class GetPaymentDetailDetailRequest : IRequest<PaymentDetailDto>
    {
        public int Id { get; set; }
    }
}
