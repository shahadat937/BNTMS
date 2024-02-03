using MediatR;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands
{
    public class UpdateTraineeAssignmentSubmitCommand : IRequest<Unit>
    {
        public TraineeAssignmentSubmitDto TraineeAssignmentSubmitDto { get; set; }
    }
}
