using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class InterServiceCourseReport : BaseDomainEntity
    {

        public int InterServiceCourseReportid { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public string? Remarks { get; set; }
        public string? Doc { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }
    }
}
