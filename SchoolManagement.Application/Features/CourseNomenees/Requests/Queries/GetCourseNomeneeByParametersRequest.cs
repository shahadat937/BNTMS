using MediatR;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Queries
{
    public class GetCourseNomeneeByParametersRequest : IRequest<List<CourseNomeneeDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int BnaSubjectNameId { get; set; } 
        public int BnaSemesterId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
    }
}
 