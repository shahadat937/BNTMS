using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedTraineeByTypeAndBaseSpRequest : IRequest<object>
    {
        public int BaseNameId { get; set; }
        public int OfficerTypeId { get; set; }
    }
}
