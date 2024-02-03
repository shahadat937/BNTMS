using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequest : IRequest<object>
    {
        public int BnaSemesterDurationId { get; set; }
    }
}
  