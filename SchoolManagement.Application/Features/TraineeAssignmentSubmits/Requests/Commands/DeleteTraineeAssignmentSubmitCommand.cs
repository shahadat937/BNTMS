using MediatR;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands
{
    public class DeleteTraineeAssignmentSubmitCommand : IRequest
    {
        public int TraineeAssignmentSubmitId { get; set; }
    }
}
