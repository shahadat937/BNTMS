using MediatR;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetTraineeMarkListByDurationForQexamSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
 