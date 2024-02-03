using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByDurationForStuffClgSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
 