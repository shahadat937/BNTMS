using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetCourseInstructorByParametersRequest : IRequest<List<CourseInstructorDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int BnaSubjectNameId { get; set; } 
        public int CourseModuleId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
    }
}
 