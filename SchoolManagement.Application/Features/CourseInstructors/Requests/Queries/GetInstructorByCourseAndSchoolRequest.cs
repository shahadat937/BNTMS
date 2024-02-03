using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorByCourseAndSchoolRequest : IRequest<List<CourseInstructorDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
    }
}
 