using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetCourseInstructorByCourseDurationAndSubjectNameIdRequest : IRequest<List<CourseInstructorDto>>
    {
        public int BnaSubjectNameId { get; set; }  
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
 