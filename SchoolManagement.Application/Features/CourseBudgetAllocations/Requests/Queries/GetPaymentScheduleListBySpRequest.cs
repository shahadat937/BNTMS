using MediatR;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetPaymentScheduleListBySpRequest : IRequest<object>
    {
        public int? CourseDurationId { get; set; }
    }
}
