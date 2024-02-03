using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByDurationSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
 