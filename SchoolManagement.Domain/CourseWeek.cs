using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseWeek : BaseDomainEntity
    {
        public CourseWeek()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
        }
        public int CourseWeekId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? WeekName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
    }
}
