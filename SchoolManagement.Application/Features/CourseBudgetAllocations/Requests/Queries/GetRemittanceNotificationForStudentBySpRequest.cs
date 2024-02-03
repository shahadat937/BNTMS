using MediatR;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetRemittanceNotificationForStudentBySpRequest : IRequest<object>
    {
        public int? TraineeId { get; set; }
        public int? CourseDurationId { get; set; }
    }
}
