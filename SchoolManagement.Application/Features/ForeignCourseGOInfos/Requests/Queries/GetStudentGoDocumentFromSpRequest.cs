using MediatR;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries
{
    public class GetStudentGoDocumentFromSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
