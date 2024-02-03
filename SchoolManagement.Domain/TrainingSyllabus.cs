using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TrainingSyllabus : BaseDomainEntity
    {

        public int TrainingSyllabusId { get; set; }
        public int? TrainingObjectiveId { get; set; }
        public int? CourseTaskId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? SyllabusDetail { get; set; }
        public int? T { get; set; }
        public int? P { get; set; }
        public int? M { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual CourseTask? CourseTask { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual TrainingObjective? TrainingObjective { get; set; }


    }
}
