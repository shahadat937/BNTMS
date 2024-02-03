using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ClassInstructorAssign : BaseDomainEntity
    {
        public int ClassInstructorAssignId { get; set; }
        public int? BnaClassScheduleId { get; set; }
        public int? TraineeId { get; set; }
        public int? DurationForm { get; set; }
        public int? DurationTo { get; set; }
        public int? Date { get; set; }
        public int? ClassLocation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }

        public virtual BnaClassSchedule? BnaClassSchedule { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
