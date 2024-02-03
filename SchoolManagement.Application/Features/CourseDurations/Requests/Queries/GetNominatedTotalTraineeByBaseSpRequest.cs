using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedTotalTraineeByBaseSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
    }
}
