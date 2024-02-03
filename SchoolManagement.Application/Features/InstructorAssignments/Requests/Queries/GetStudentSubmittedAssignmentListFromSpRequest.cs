using MediatR;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetStudentSubmittedAssignmentListFromSpRequest : IRequest<object>
    {
        public int InstructorAssignmentId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}
