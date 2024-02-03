using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetMarkSheetByTraineeIdAndDurationSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
 