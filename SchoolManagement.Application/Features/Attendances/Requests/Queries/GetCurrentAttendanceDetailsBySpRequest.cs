using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetCurrentAttendanceDetailsBySpRequest : IRequest<object>
    {
        public DateTime? CurrentDate { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
    }
}
