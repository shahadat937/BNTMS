using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetCurrentAttendanceDetailsByRoutineSpRequest : IRequest<object>
    {
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassRoutineId { get; set; }
    }
}
