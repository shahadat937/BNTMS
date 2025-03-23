using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetInterServiceNominatedTraineeForProfileUpdateSpRequest : IRequest<object>
    {
        public string SearchText { get; set; }
    }
}
  