using MediatR;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands
{
    public class StopTraineeAssignmentSubmitCommand : IRequest
    {
        public int TraineeAssignmentSubmitId { get; set; }  
    }
}
   