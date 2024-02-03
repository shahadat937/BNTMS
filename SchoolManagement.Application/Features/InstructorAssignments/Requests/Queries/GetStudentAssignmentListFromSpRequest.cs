using MediatR;

namespace SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries
{
    public class GetStudentAssignmentListFromSpRequest : IRequest<object>
    {
        public DateTime? CurrentDate { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
