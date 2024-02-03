using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationListByTypeAndCourseDurationIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
  