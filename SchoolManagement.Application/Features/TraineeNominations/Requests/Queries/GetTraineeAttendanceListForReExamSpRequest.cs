using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeAttendanceListForReExamSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
        public int AttendanceStatus { get; set; }
        public int BaseSchoolNameId { get; set; } 
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }
        public int ClassRoutineId { get; set; }
    }
}
   