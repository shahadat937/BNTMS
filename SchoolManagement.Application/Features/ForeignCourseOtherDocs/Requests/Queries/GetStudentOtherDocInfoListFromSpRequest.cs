using MediatR;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries
{
    public class GetStudentOtherDocInfoListFromSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
