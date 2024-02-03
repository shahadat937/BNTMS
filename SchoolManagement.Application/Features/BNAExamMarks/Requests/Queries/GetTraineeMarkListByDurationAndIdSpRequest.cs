using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByDurationAndIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int TraineeId { get; set; }
    }
}
 