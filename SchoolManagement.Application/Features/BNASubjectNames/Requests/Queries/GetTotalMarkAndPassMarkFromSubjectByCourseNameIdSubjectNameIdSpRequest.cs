using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequest : IRequest<object>
    {
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; } 
    }
}
  