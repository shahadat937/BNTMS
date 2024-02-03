using MediatR;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries
{
    public class GetStudentOtherDocumentsFromSpRequest : IRequest<object>
    {
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
