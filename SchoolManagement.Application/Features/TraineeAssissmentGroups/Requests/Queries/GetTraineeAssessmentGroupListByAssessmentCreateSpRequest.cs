using MediatR;

namespace SchoolManagement.Application.Features.TraineeAssessmentGroups.Requests.Queries
{
    public class GetTraineeAssessmentGroupListByAssessmentCreateSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int TraineeAssessmentCreateId { get; set; }
        public string SearchText { get; set; }
    }
} 
  