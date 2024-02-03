using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class BnaClassSchedule : BaseDomainEntity
    {
        public BnaClassSchedule()
        {
            ClassInstructorAssigns = new HashSet<ClassInstructorAssign>();
        }

        public int BnaClassScheduleId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? BnaClassScheduleStatusId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? Date { get; set; }
        public string? ClassLocation { get; set; }
        public bool ClassCompletedStatus { get; set; }
        public string? DurationForm { get; set; }
        public string? DurationTo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaBatch? BnaBatch { get; set; }
        public virtual BnaClassScheduleStatus? BnaClassScheduleStatus { get; set; }
        public virtual BnaClassSectionSelection? BnaClassSectionSelection { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual ClassPeriod? ClassPeriod { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual ICollection<ClassInstructorAssign> ClassInstructorAssigns { get; set; }
    }
}
