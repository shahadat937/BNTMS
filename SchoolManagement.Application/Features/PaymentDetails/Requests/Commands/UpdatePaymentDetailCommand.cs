using MediatR;
using SchoolManagement.Application.DTOs.PaymentDetail;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Commands
{
    public class UpdatePaymentDetailCommand : IRequest<Unit> 
    { 
        public PaymentDetailDto PaymentDetailDto { get; set; }   
    }
}
