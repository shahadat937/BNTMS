using MediatR;
using SchoolManagement.Application.DTOs.PaymentType;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Commands
{
    public class UpdatePaymentTypeCommand : IRequest<Unit>
    {
        public PaymentTypeDto PaymentTypeDto { get; set; }
    }
}
