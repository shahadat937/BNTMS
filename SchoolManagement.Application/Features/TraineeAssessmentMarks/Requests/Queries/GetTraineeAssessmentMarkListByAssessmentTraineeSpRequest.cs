using MediatR;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries
{
    public class GetTraineeAssessmentMarkListByAssessmentTraineeSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int TraineeAssessmentCreateId { get; set; }
        public int AssessmentTraineeId { get; set; }
    }
} 
  