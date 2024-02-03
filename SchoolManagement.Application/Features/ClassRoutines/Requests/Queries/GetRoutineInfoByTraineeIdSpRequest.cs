using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetRoutineInfoByTraineeIdSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseSectionId { get; set; }
        public int WeekStatus { get; set; }
    }
}
