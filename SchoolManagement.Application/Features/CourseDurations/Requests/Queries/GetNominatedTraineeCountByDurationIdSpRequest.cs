using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedTraineeCountByDurationIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
