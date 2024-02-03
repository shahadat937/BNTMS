using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class ChangeTraineeAssessmentStatusCommand : IRequest
    {
        public int TraineeAssessmentCreateId { get; set; }
        public int Status { get; set; }
    }
}
 