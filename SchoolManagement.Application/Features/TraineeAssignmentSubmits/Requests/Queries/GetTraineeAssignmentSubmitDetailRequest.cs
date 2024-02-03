using MediatR;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries
{
    public class GetTraineeAssignmentSubmitDetailRequest : IRequest<TraineeAssignmentSubmitDto>
    {
        public int TraineeAssignmentSubmitId { get; set; }
    }
}
