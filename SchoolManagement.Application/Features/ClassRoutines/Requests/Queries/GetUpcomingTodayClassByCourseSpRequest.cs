using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetUpcomingTodayClassByCourseSpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; } 
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; }
        public int TraineeId { get; set; }
    }
}  
 