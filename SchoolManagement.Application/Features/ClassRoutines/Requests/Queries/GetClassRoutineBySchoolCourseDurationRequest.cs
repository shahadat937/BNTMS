using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineBySchoolCourseDurationRequest : IRequest<List<ClassRoutineDto>>
    {
        public int BaseSchoolNameId { get; set; }  
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}

 