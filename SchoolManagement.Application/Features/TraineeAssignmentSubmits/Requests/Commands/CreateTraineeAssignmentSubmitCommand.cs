using MediatR;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands
{
    public class CreateTraineeAssignmentSubmitCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeAssignmentSubmitDto TraineeAssignmentSubmitDto { get; set; }
    }
}
