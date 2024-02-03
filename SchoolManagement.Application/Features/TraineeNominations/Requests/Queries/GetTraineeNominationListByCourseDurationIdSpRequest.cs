using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationListByCourseDurationIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
  