using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineByCourseNameBaseSchoolNameSpRequestRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }  
        public int CourseNameId { get; set; } 
        public int CourseWeekId { get; set; } 
        public int CourseSectionId { get; set; } 
    }
}

 