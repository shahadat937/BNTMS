using SchoolManagement.Application.DTOs.ClassRoutine;
using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineListByParamsRequest : IRequest<List<ClassRoutineDto>>
    {
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? CourseSectionId { get; set; }
    }
}
