using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetNominatedTraineeForProfileUpdateSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    }
}
  