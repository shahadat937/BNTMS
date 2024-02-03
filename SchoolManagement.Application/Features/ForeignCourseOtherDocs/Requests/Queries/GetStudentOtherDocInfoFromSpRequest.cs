using MediatR;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries
{
    public class GetStudentOtherDocInfoFromSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
