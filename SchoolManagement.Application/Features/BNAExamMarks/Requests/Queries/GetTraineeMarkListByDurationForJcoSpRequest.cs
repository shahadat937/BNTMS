using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByDurationForJcoSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
 