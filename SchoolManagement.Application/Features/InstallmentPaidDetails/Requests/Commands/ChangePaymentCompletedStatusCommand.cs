 using MediatR;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands
{
    public class ChangePaymentCompletedStatusCommand : IRequest
    {
        public int InstallmentPaidDetailId { get; set; }
        public int PaymentCompletedStatus { get; set; }
    }
}
