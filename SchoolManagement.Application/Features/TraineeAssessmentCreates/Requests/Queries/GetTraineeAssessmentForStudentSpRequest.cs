using MediatR;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries
{
    public class GetTraineeAssessmentForStudentSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; }
        public int CourseDurationId { get; set; }
        public int TraineeId { get; set; }
    }
} 
  