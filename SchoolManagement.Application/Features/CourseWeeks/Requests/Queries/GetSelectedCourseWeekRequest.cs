using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetSelectedCourseWeekRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
        public int? Status { get; set; }
    }
}
