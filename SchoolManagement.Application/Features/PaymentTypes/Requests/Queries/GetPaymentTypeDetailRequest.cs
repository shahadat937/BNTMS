using MediatR;
using SchoolManagement.Application.DTOs.PaymentType;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Queries
{
    public class GetPaymentTypeDetailRequest : IRequest<PaymentTypeDto>
    {
        public int PaymentTypeId { get; set; }
    }
}
