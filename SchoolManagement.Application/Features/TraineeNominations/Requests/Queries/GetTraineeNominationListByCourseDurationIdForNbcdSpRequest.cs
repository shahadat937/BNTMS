using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationListByCourseDurationIdForNbcdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
   